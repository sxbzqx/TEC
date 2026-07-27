using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using tecBackend.Dtos;
using tecBackend.Models;
using tecBackend.Services;
using tecBackend.Utils;

namespace tecBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SiteContext _context;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;

    public AuthController(
        SiteContext context,
        ITokenService tokenService,
        IPasswordHasher passwordHasher
    )
    {
        _context = context;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Информация о пользователе: роль, логин, отдел.  
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userIdClaim =
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        var user = await _context
            .Users.Include(u => u.Otdel)
            .FirstOrDefaultAsync(u => u.Id == int.Parse(userIdClaim));

        if (user == null)
            return NotFound();

        return Ok(
            new
            {
                role = user.Role ?? "Worker",
                loginName = user.Login,
                department = user.Otdel != null ? user.Otdel.NameOtd : "Не указан",
            }
        );
    }


    /// <summary>
    /// Отделы. 
    /// </summary>
    [HttpGet("otdels")]
    public async Task<IActionResult> GetOtdels()
    {
        var otdels = await _context.Otdels.Select(o => new { o.Id, o.NameOtd }).ToListAsync();
        return Ok(otdels);
    }

    /// <summary>
    /// Регистрация обычного пользователя — без привязки к отделу и без проверки по табельному номеру.
    /// </summary>
    [HttpPost("register")]
    [EnableRateLimiting("auth")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Логин и пароль обязательны" });
        }

        if (request.Password.Length < 6)
        {
            return BadRequest(new { message = "Пароль должен содержать минимум 6 символов" });
        }

        var userExists = await _context.Users.AnyAsync(u => u.Login == request.Login);
        if (userExists)
        {
            return BadRequest(new { message = "Пользователь с таким логином уже существует" });
        }

        var newUser = new User
        {
            Login = request.Login,
            Password = _passwordHasher.Hash(request.Password),
            Mail = request.Mail,
            Role = "User",
            ComeDate = BishkekClock.Now,
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Регистрация прошла успешно" });
    }

    /// <summary>
    /// Регистрации сотрудника: поиск по табельному номеру в справочнике workers.
    /// Просто подтверждает, что запись найдена и ещё не привязана к аккаунту —
    /// саму личность подтверждаем на EmployeeRegister, по ФИО и дате рождения.
    /// </summary>
    [HttpPost("employee/lookup")]
    [EnableRateLimiting("auth")]
    public async Task<IActionResult> EmployeeLookup([FromBody] EmployeeLookupRequest request)
    {
        var tabel = request.Tabel?.Trim();
        if (string.IsNullOrEmpty(tabel))
        {
            return BadRequest(new { message = "Укажите табельный номер" });
        }

        var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Tabel == tabel);
        if (worker == null)
        {
            return NotFound(new { message = "Сотрудник с таким табельным номером не найден" });
        }

        var alreadyRegistered = await _context.Users.AnyAsync(u => u.Tabel == worker.Tabel);
        if (alreadyRegistered)
        {
            return Conflict(new { message = "Для этого табельного номера уже создан аккаунт. Обратитесь к администратору, если это не вы." });
        }

        return Ok(new EmployeeLookupResponse(worker.Otdel, worker.Doljnost));
    }

    /// <summary>
    /// Промежуточный шаг перед вводом логина/пароля: проверяет ФИО и дату
    /// рождения, ничего не создавая — чтобы ошибка "не совпадает" всплывала
    /// сразу, а не после заполнения всей формы credentials. EmployeeRegister
    /// всё равно перепроверяет то же самое перед созданием аккаунта — этот
    /// эндпоинт только для UX, не единственная точка защиты.
    /// </summary>
    [HttpPost("employee/verify")]
    [EnableRateLimiting("auth")]
    public async Task<IActionResult> EmployeeVerify([FromBody] EmployeeVerifyRequest request)
    {
        var tabel = request.Tabel?.Trim();
        if (string.IsNullOrEmpty(tabel) || string.IsNullOrWhiteSpace(request.Fio))
        {
            return BadRequest(new { message = "Заполнены не все поля" });
        }

        var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Tabel == tabel);
        if (worker == null)
        {
            return NotFound(new { message = "Сотрудник с таким табельным номером не найден" });
        }

        var alreadyRegistered = await _context.Users.AnyAsync(u => u.Tabel == worker.Tabel);
        if (alreadyRegistered)
        {
            return Conflict(new { message = "Для этого табельного номера уже создан аккаунт" });
        }

        if (!FioMatches(request.Fio, worker.Fio) || request.BirthDate.Date != worker.Dr.Date)
        {
            return BadRequest(new { message = "ФИО или дата рождения не совпадают с данными в системе" });
        }

        return Ok(new { message = "Личность подтверждена" });
    }

    /// <summary>
    /// Регистрации сотрудника: сверяем введённые ФИО и дату рождения
    /// с кадровой записью (worker), и только при совпадении — установка
    /// логина/пароля/почты и создание аккаунта, привязанного к отделу
    /// из справочника workers.
    /// </summary>
    [HttpPost("employee/register")]
    [EnableRateLimiting("auth")]
    public async Task<IActionResult> EmployeeRegister([FromBody] EmployeeRegisterRequest request)
    {
        var tabel = request.Tabel?.Trim();
        if (string.IsNullOrEmpty(tabel))
        {
            return BadRequest(new { message = "Укажите табельный номер" });
        }

        if (string.IsNullOrWhiteSpace(request.Fio))
        {
            return BadRequest(new { message = "Укажите ФИО" });
        }

        if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
        {
            return BadRequest(new { message = "Логин и пароль обязательны" });
        }

        if (request.Password.Length < 6)
        {
            return BadRequest(new { message = "Пароль должен содержать минимум 6 символов" });
        }

        var worker = await _context.Workers.FirstOrDefaultAsync(w => w.Tabel == tabel);
        if (worker == null)
        {
            return NotFound(new { message = "Сотрудник с таким табельным номером не найден" });
        }

        var alreadyRegistered = await _context.Users.AnyAsync(u => u.Tabel == worker.Tabel);
        if (alreadyRegistered)
        {
            return Conflict(new { message = "Для этого табельного номера уже создан аккаунт" });
        }

        // Проверка личности: сотрудник должен сам знать своё ФИО и дату рождения
        // как в кадровой базе — иначе кто угодно, подобрав табельный номер,
        // мог бы зарегистрироваться от чужого имени. Один и тот же текст
        // ошибки для обоих полей, чтобы не подсказывать, какое из них неверно.
        if (!FioMatches(request.Fio, worker.Fio) || request.BirthDate.Date != worker.Dr.Date)
        {
            return BadRequest(new { message = "ФИО или дата рождения не совпадают с данными в системе" });
        }

        var loginTaken = await _context.Users.AnyAsync(u => u.Login == request.Login);
        if (loginTaken)
        {
            return BadRequest(new { message = "Пользователь с таким логином уже существует" });
        }

        // worker.OtdelId — числовой код, который не соответствует ни otdel.Id,
        // ни otdel.IdOtd (сверено на реальных данных: например, у "Котельный
        // цех" otdelID=59, а в otdel этот же цех имеет id=11/id_otd=13 —
        // числа из разных систем координат). Надёжно совпадает только текст:
        // worker.Otdel ("отдел рус.полностью") дословно равен otdel.NameOtd.
        var otdel = await _context.Otdels.FirstOrDefaultAsync(
            o => o.NameOtd.Trim() == worker.Otdel.Trim()
        );

        var newUser = new User
        {
            Login = request.Login,
            Password = _passwordHasher.Hash(request.Password),
            Mail = request.Mail,
            Tabel = worker.Tabel,
            OtdelId = otdel?.Id,
            Role = "Worker",
            ComeDate = BishkekClock.Now,
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Регистрация прошла успешно" });
    }

    /// <summary>
    /// Сравнивает введённое сотрудником ФИО с записью в workers: без учёта
    /// регистра, лишних пробелов и разницы "ё"/"е" (частый источник ложных
    /// несовпадений в русских ФИО — в базе имя может быть записано и так,
    /// и так). Без "нечёткого" совпадения сверх этого — это проверка
    /// личности, а не подсказка.
    /// </summary>
    private static bool FioMatches(string input, string actual)
    {
        static string Normalize(string s) =>
            string
                .Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Trim()
                .Replace('ё', 'е')
                .Replace('Ё', 'Е');

        return string.Equals(Normalize(input), Normalize(actual), StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Вход в аккаунт. 
    /// </summary>
    [HttpPost("login")]
    [EnableRateLimiting("auth")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == request.Login);

        if (user != null && user.Ban == 1)
        {
            return StatusCode(403, new { message = $"Вы забанены. Причина: {user.BanComment}" });
        }

        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
        {
            return Unauthorized(new { message = "Неверный логин или пароль" });
        }

        // Лёгкая миграция: пароль ещё хранился в открытом виде — перехешируем
        if (!_passwordHasher.IsHashed(user.Password))
        {
            user.Password = _passwordHasher.Hash(request.Password);
            await _context.SaveChangesAsync();
        }

        var userRole = string.IsNullOrEmpty(user.Role) ? "Worker" : user.Role;

        var accessToken = _tokenService.GenerateAccessToken(user.Id, user.Login, userRole);
        var refreshToken = _tokenService.GenerateRefreshToken();

        var session = new UserSession
        {
            UserId = user.Id,
            RefreshToken = RefreshTokenHasher.Hash(refreshToken),
            ExpiryTime = DateTime.UtcNow.AddDays(7),
        };

        _context.UserSessions.Add(session);
        await _context.SaveChangesAsync();

        return Ok(new TokenResponse(accessToken, refreshToken, userRole));
    }

    /// <summary>
    /// Выход из аккаунта.
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.RefreshToken))
        {
            return BadRequest(new { message = "Отсутствует токен для выхода" });
        }

        var hashedToken = RefreshTokenHasher.Hash(request.RefreshToken);
        var session = await _context.UserSessions.FirstOrDefaultAsync(s =>
            s.RefreshToken == hashedToken
        );

        if (session != null)
        {
            _context.UserSessions.Remove(session);
            await _context.SaveChangesAsync();
        }

        return Ok(new { message = "Сессия успешно завершена на сервере" });
    }


    /// <summary>
    /// Refresh Access-токена.
    /// </summary>
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    {
        var hashedToken = RefreshTokenHasher.Hash(request.RefreshToken);
        var session = await _context.UserSessions.FirstOrDefaultAsync(s =>
            s.RefreshToken == hashedToken
        );

        if (session == null || session.ExpiryTime <= DateTime.UtcNow)
        {
            return BadRequest(new { message = "Невалидный или просроченный токен сессии" });
        }

        var user = await _context.Users.FindAsync(session.UserId);
        if (user == null)
        {
            return BadRequest(new { message = "Пользователь не найден" });
        }

        var userRole = string.IsNullOrEmpty(user.Role) ? "Worker" : user.Role;

        var newAccessToken = _tokenService.GenerateAccessToken(user.Id, user.Login, userRole);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        session.RefreshToken = RefreshTokenHasher.Hash(newRefreshToken);
        session.ExpiryTime = DateTime.UtcNow.AddDays(7);
        await _context.SaveChangesAsync();

        return Ok(new TokenResponse(newAccessToken, newRefreshToken, userRole));
    }

    /// <summary>
    /// Смена пароля. 
    /// </summary>
    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userIdClaim =
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        if (string.IsNullOrWhiteSpace(request.NewPassword) || request.NewPassword.Length < 6)
            return BadRequest(new { message = "Новый пароль должен содержать минимум 6 символов" });

        var user = await _context.Users.FindAsync(int.Parse(userIdClaim));
        if (user == null)
            return NotFound();

        if (!_passwordHasher.Verify(request.CurrentPassword, user.Password))
            return BadRequest(new { message = "Текущий пароль указан неверно" });

        if (_passwordHasher.Verify(request.NewPassword, user.Password))
            return BadRequest(new { message = "Новый пароль должен отличаться от текущего" });

        user.Password = _passwordHasher.Hash(request.NewPassword);
        await _context.SaveChangesAsync();

        // Разлогиниваем все сессии, КРОМЕ текущей — её refresh-токен передаёт фронт.
        // Если токен не передан — старое поведение (выходим везде).
        var sessionsQuery = _context.UserSessions.Where(s => s.UserId == user.Id);

        var currentToken = request.CurrentRefreshToken?.Trim();
        if (!string.IsNullOrEmpty(currentToken))
        {
            var currentHashed = RefreshTokenHasher.Hash(currentToken);
            sessionsQuery = sessionsQuery.Where(s => s.RefreshToken != currentHashed);
        }

        var sessionsToRemove = await sessionsQuery.ToListAsync();
        _context.UserSessions.RemoveRange(sessionsToRemove);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Пароль успешно изменён" });
    }

    /// <summary>
    /// Смена логина. 
    /// </summary>
    [HttpPost("change-login")]
    [Authorize]
    public async Task<IActionResult> ChangeLogin([FromBody] ChangeLoginRequest request)
    {
        var userIdClaim =
            User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("sub")?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
            return Unauthorized();

        if (string.IsNullOrWhiteSpace(request.NewLogin))
            return BadRequest(new { message = "Новый логин не может быть пустым" });

        var user = await _context.Users.FindAsync(int.Parse(userIdClaim));
        if (user == null)
            return NotFound();

        if (!_passwordHasher.Verify(request.CurrentPassword, user.Password))
            return BadRequest(new { message = "Пароль указан неверно" });

        var loginTaken = await _context.Users.AnyAsync(u =>
            u.Login == request.NewLogin && u.Id != user.Id
        );
        if (loginTaken)
            return BadRequest(new { message = "Этот логин уже занят" });

        user.Login = request.NewLogin;
        await _context.SaveChangesAsync();

        var userRole = string.IsNullOrEmpty(user.Role) ? "Worker" : user.Role;
        var newAccessToken = _tokenService.GenerateAccessToken(user.Id, user.Login, userRole);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        var oldSessions = _context.UserSessions.Where(s => s.UserId == user.Id);
        _context.UserSessions.RemoveRange(oldSessions);

        _context.UserSessions.Add(
            new UserSession
            {
                UserId = user.Id,
                RefreshToken = RefreshTokenHasher.Hash(newRefreshToken),
                ExpiryTime = DateTime.UtcNow.AddDays(7),
            }
        );

        await _context.SaveChangesAsync();

        return Ok(new TokenResponse(newAccessToken, newRefreshToken, userRole));
    }
}