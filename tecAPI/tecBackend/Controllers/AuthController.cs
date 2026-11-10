using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using tecBackend.Dtos;
using tecBackend.Extensions;
using tecBackend.Models;
using tecBackend.Services;
using tecBackend.Utils;

namespace tecBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private const int MinPasswordLength = 6;
    private static readonly TimeSpan RefreshLifetime = TimeSpan.FromDays(7);

    private readonly SiteContext _context;
    private readonly ITokenService _tokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IActivityLogService _activityLog;
    private readonly IEmployeeVerificationService _employees;

    public AuthController(
        SiteContext context,
        ITokenService tokenService,
        IPasswordHasher passwordHasher,
        IActivityLogService activityLog,
        IEmployeeVerificationService employees
    )
    {
        _context = context;
        _tokenService = tokenService;
        _passwordHasher = passwordHasher;
        _activityLog = activityLog;
        _employees = employees;
    }

    /// <summary>
    /// Информация о пользователе: роль, логин, отдел.
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        if (User.GetUserId() is not int userId)
            return Unauthorized();

        var user = await _context.Users.Include(u => u.Otdel).FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            return NotFound();

        string? fio = null;
        if (!string.IsNullOrEmpty(user.Tabel))
        {
            fio = await _context.Workers
                .Where(w => w.Tabel == user.Tabel)
                .Select(w => w.Fio)
                .FirstOrDefaultAsync();
        }

        return Ok(
            new
            {
                role = user.Role ?? "Worker",
                loginName = user.Login,
                department = user.Otdel != null ? user.Otdel.NameOtd : "Не указан",
                fio,
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
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var error = ValidateCredentials(request.Login, request.Password);
        if (error != null)
            return BadRequest(new { message = error });

        if (await _context.Users.AnyAsync(u => u.Login == request.Login))
            return BadRequest(new { message = "Пользователь с таким логином уже существует" });

        var newUser = new User
        {
            Login = request.Login,
            Password = _passwordHasher.Hash(request.Password),
            Mail = request.Mail,
            Role = "User",
            ComeDate = BishkekClock.Now,
        };

        _context.Users.Add(newUser);
        _activityLog.Log("user_registered", "Зарегистрирован новый пользователь", newUser.Login);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (IsUniqueViolation(ex))
        {
            return BadRequest(new { message = "Пользователь с таким логином уже существует" });
        }

        return Ok(new { message = "Регистрация прошла успешно" });
    }

    /// <summary>
    /// Регистрация сотрудника, шаг 1: поиск по табельному номеру в справочнике workers.
    /// Подтверждает, что запись найдена и ещё не привязана к аккаунту —
    /// личность подтверждаем на следующих шагах, по ФИО и дате рождения.
    /// </summary>
    [HttpPost("employee/lookup")]
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> EmployeeLookup([FromBody] EmployeeLookupRequest request)
    {
        var result = await _employees.FindAvailableWorkerAsync(request.Tabel);
        if (!result.IsOk)
            return ToActionResult(result);

        return Ok(new EmployeeLookupResponse(result.Worker!.Otdel, result.Worker.Doljnost));
    }

    /// <summary>
    /// Регистрация сотрудника, шаг 2: проверяет ФИО и дату рождения, ничего не создавая —
    /// чтобы ошибка «не совпадает» всплывала сразу, а не после заполнения формы credentials.
    /// EmployeeRegister перепроверяет то же самое — этот эндпоинт только для UX.
    /// </summary>
    [HttpPost("employee/verify")]
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> EmployeeVerify([FromBody] EmployeeVerifyRequest request)
    {
        var result = await _employees.VerifyIdentityAsync(request.Tabel, request.Fio, request.BirthDate);
        if (!result.IsOk)
            return ToActionResult(result);

        return Ok(new { message = "Личность подтверждена" });
    }

    /// <summary>
    /// Регистрация сотрудника, шаг 3: повторная сверка ФИО и даты рождения с кадровой записью,
    /// затем создание аккаунта, привязанного к отделу из справочника workers.
    /// </summary>
    [HttpPost("employee/register")]
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> EmployeeRegister([FromBody] EmployeeRegisterRequest request)
    {
        var error = ValidateCredentials(request.Login, request.Password);
        if (error != null)
            return BadRequest(new { message = error });

        var result = await _employees.VerifyIdentityAsync(request.Tabel, request.Fio, request.BirthDate);
        if (!result.IsOk)
            return ToActionResult(result);

        var worker = result.Worker!;

        if (await _context.Users.AnyAsync(u => u.Login == request.Login))
            return BadRequest(new { message = "Пользователь с таким логином уже существует" });

        var newUser = new User
        {
            Login = request.Login,
            Password = _passwordHasher.Hash(request.Password),
            Mail = request.Mail,
            Tabel = worker.Tabel,
            OtdelId = await _employees.ResolveOtdelIdAsync(worker),
            Role = "Worker",
            ComeDate = BishkekClock.Now,
        };

        _context.Users.Add(newUser);
        _activityLog.Log(
            "employee_registered",
            $"Зарегистрирован сотрудник {worker.Fio}",
            $"логин: {newUser.Login}, таб. №{worker.Tabel}"
        );

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (IsUniqueViolation(ex))
        {
            // Гонка: параллельный запрос успел занять логин или табельный номер
            return Conflict(new { message = "Логин или табельный номер уже зарегистрирован" });
        }

        return Ok(new { message = "Регистрация прошла успешно" });
    }

    /// <summary>
    /// Вход в аккаунт.
    /// </summary>
    [HttpPost("login")]
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == request.Login);

        // Пароль проверяем ДО бана: иначе по логину можно узнать, что аккаунт существует и забанен
        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            return Unauthorized(new { message = "Неверный логин или пароль" });

        if (user.Ban == 1)
            return StatusCode(403, new { message = $"Вы забанены. Причина: {user.BanComment}" });

        // Лёгкая миграция: пароль ещё хранился в открытом виде — перехешируем
        if (!_passwordHasher.IsHashed(user.Password))
        {
            user.Password = _passwordHasher.Hash(request.Password);
            await _context.SaveChangesAsync();
        }

        var role = GetRole(user);
        var accessToken = _tokenService.GenerateAccessToken(user.Id, user.Login, role);
        var refreshToken = _tokenService.GenerateRefreshToken();

        _context.UserSessions.Add(CreateSession(user.Id, refreshToken));
        await _context.SaveChangesAsync();

        return Ok(new TokenResponse(accessToken, refreshToken, role));
    }

    /// <summary>
    /// Выход из аккаунта.
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.RefreshToken))
            return BadRequest(new { message = "Отсутствует токен для выхода" });

        var hashedToken = RefreshTokenHasher.Hash(request.RefreshToken);
        var session = await _context.UserSessions.FirstOrDefaultAsync(s => s.RefreshToken == hashedToken);

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
        if (request == null || string.IsNullOrEmpty(request.RefreshToken))
            return BadRequest(new { message = "Невалидный или просроченный токен сессии" });

        var hashedToken = RefreshTokenHasher.Hash(request.RefreshToken);
        var session = await _context.UserSessions.FirstOrDefaultAsync(s => s.RefreshToken == hashedToken);

        if (session == null || session.ExpiryTime <= DateTime.UtcNow)
            return BadRequest(new { message = "Невалидный или просроченный токен сессии" });

        var user = await _context.Users.FindAsync(session.UserId);
        if (user == null)
            return BadRequest(new { message = "Пользователь не найден" });

        if (user.Ban == 1)
        {
            _context.UserSessions.RemoveRange(_context.UserSessions.Where(s => s.UserId == user.Id));
            await _context.SaveChangesAsync();
            return StatusCode(403, new { message = "Аккаунт заблокирован" });
        }

        var role = GetRole(user);
        var newAccessToken = _tokenService.GenerateAccessToken(user.Id, user.Login, role);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        session.RefreshToken = RefreshTokenHasher.Hash(newRefreshToken);
        session.ExpiryTime = DateTime.UtcNow.Add(RefreshLifetime);
        await _context.SaveChangesAsync();

        return Ok(new TokenResponse(newAccessToken, newRefreshToken, role));
    }

    /// <summary>
    /// Смена пароля.
    /// </summary>
    [HttpPost("change-password")]
    [Authorize]
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        if (User.GetUserId() is not int userId)
            return Unauthorized();

        if (string.IsNullOrWhiteSpace(request.NewPassword) || request.NewPassword.Length < MinPasswordLength)
            return BadRequest(new { message = $"Новый пароль должен содержать минимум {MinPasswordLength} символов" });

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return NotFound();

        if (!_passwordHasher.Verify(request.CurrentPassword, user.Password))
            return BadRequest(new { message = "Текущий пароль указан неверно" });

        if (_passwordHasher.Verify(request.NewPassword, user.Password))
            return BadRequest(new { message = "Новый пароль должен отличаться от текущего" });

        user.Password = _passwordHasher.Hash(request.NewPassword);

        _activityLog.Log(
            "password_changed",
            $"Пользователь {user.Login} сменил пароль",
            actorUserId: user.Id
        );

        // Разлогиниваем все сессии, КРОМЕ текущей — её refresh-токен передаёт фронт.
        // Если токен не передан — выходим везде.
        var sessionsQuery = _context.UserSessions.Where(s => s.UserId == user.Id);

        var currentToken = request.CurrentRefreshToken?.Trim();
        if (!string.IsNullOrEmpty(currentToken))
        {
            var currentHashed = RefreshTokenHasher.Hash(currentToken);
            sessionsQuery = sessionsQuery.Where(s => s.RefreshToken != currentHashed);
        }

        _context.UserSessions.RemoveRange(await sessionsQuery.ToListAsync());

        // Смена пароля и сброс сессий — одним SaveChanges, т.е. одной транзакцией
        await _context.SaveChangesAsync();

        return Ok(new { message = "Пароль успешно изменён" });
    }

    /// <summary>
    /// Смена логина.
    /// </summary>
    [HttpPost("change-login")]
    [Authorize]
    [EnableRateLimiting(RateLimitingExtensions.AuthPolicy)]
    public async Task<IActionResult> ChangeLogin([FromBody] ChangeLoginRequest request)
    {
        if (User.GetUserId() is not int userId)
            return Unauthorized();

        if (string.IsNullOrWhiteSpace(request.NewLogin))
            return BadRequest(new { message = "Новый логин не может быть пустым" });

        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return NotFound();

        if (!_passwordHasher.Verify(request.CurrentPassword, user.Password))
            return BadRequest(new { message = "Пароль указан неверно" });

        if (await _context.Users.AnyAsync(u => u.Login == request.NewLogin && u.Id != user.Id))
            return BadRequest(new { message = "Этот логин уже занят" });

        var oldLogin = user.Login;
        user.Login = request.NewLogin;

        _activityLog.Log(
            "login_changed",
            "Пользователь сменил логин",
            $"{oldLogin} → {request.NewLogin}",
            actorUserId: user.Id
        );

        // Старые сессии заменяем одной новой — в том же SaveChanges
        _context.UserSessions.RemoveRange(_context.UserSessions.Where(s => s.UserId == user.Id));

        var role = GetRole(user);
        var newAccessToken = _tokenService.GenerateAccessToken(user.Id, user.Login, role);
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        _context.UserSessions.Add(CreateSession(user.Id, newRefreshToken));

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (IsUniqueViolation(ex))
        {
            return BadRequest(new { message = "Этот логин уже занят" });
        }

        return Ok(new TokenResponse(newAccessToken, newRefreshToken, role));
    }

    // ───────────── helpers ─────────────

    private static string GetRole(User user) => string.IsNullOrEmpty(user.Role) ? "Worker" : user.Role;

    private static UserSession CreateSession(int userId, string refreshToken) =>
        new()
        {
            UserId = userId,
            RefreshToken = RefreshTokenHasher.Hash(refreshToken),
            ExpiryTime = DateTime.UtcNow.Add(RefreshLifetime),
        };

    private static string? ValidateCredentials(string? login, string? password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            return "Логин и пароль обязательны";

        if (password.Length < MinPasswordLength)
            return $"Пароль должен содержать минимум {MinPasswordLength} символов";

        return null;
    }

    private IActionResult ToActionResult(EmployeeCheckResult result)
    {
        var body = new { message = result.Message };

        return result.Status switch
        {
            EmployeeCheckStatus.NotFound => NotFound(body),
            EmployeeCheckStatus.Conflict => Conflict(body),
            _ => BadRequest(body),
        };
    }

    private static bool IsUniqueViolation(DbUpdateException ex) =>
        ex.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation };
}