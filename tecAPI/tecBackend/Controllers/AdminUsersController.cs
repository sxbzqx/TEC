using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using tecBackend.Dtos;
using tecBackend.Extensions;
using tecBackend.Models;
using tecBackend.Models.DTO;
using tecBackend.Services;
using tecBackend.Utils;

namespace tecBackend.Controllers;

/// <summary>
/// Администрирование учётных записей. Правила доступа:
///  • SuperAdmin управляет всеми и может назначать любые роли;
///  • Admin управляет только User/Worker/Guest и не может выдавать Admin/SuperAdmin
///    (иначе любой Admin мог бы сделать себя SuperAdmin);
///  • роль и блокировку, сессии и пароль самому себе через эти методы менять нельзя —
///    чтобы случайно не лишить портал последнего администратора.
/// Все изменения применяются сразу: старые токены перестают работать (см. AuthExtensions),
/// а пользователь получает событие по SignalR и обновляет интерфейс без перезахода.
/// </summary>
[ApiController]
[Authorize(Roles = "SuperAdmin,Admin")]
[Route("api/admin/users")]
public class AdminUsersController(
    SiteContext context,
    IActivityLogService activityLog,
    IPasswordHasher passwordHasher,
    IPortalNotifier notifier,
    PresenceTracker presence
) : ControllerBase
{
    private const int MinPasswordLength = 6;
    private const int MaxBanCommentLength = 500;

    private int? CurrentUserId => User.GetUserId();

    private bool IsSelf(int id) => CurrentUserId == id;

    private bool IsSuperAdmin => User.IsInRole(AppRoles.SuperAdmin);

    private bool CanManage(User target) => IsSuperAdmin || !AppRoles.IsStaff(AppRoles.Normalize(target.Role));

    private bool CanAssign(string role) => IsSuperAdmin || !AppRoles.IsStaff(role);

    private ObjectResult NoRights() =>
        StatusCode(403, new { message = "Недостаточно прав для управления этой учётной записью" });

    /// <summary>Список пользователей (компактный) — для таблицы.</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var online = presence.OnlineUserIds();

        var rows = await context
            .Users.AsNoTracking()
            .OrderBy(u => u.Login)
            .Select(u => new
            {
                u.Id,
                Username = u.Login,
                Email = u.Mail,
                Role = (u.Role == null || u.Role == "") ? AppRoles.Worker : u.Role,
                IsBanned = u.Ban == 1,
                u.OtdelId,
                Otdel = u.Otdel != null ? u.Otdel.NameOtd : null,
                u.Tabel,
            })
            .ToListAsync();

        return Ok(
            rows.Select(r => new
            {
                id = r.Id,
                username = r.Username,
                email = r.Email,
                role = r.Role,
                isBanned = r.IsBanned,
                otdelId = r.OtdelId,
                otdel = r.Otdel,
                tabel = r.Tabel,
                isOnline = online.Contains(r.Id),
            })
        );
    }

    /// <summary>Карточка пользователя: профиль, кадровая запись, сессии, последние действия.</summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var user = await context
            .Users.AsNoTracking()
            .Include(u => u.Otdel)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        var worker = string.IsNullOrEmpty(user.Tabel)
            ? null
            : await context.Workers.AsNoTracking().FirstOrDefaultAsync(w => w.Tabel == user.Tabel);

        var activeSessions = await context.UserSessions.CountAsync(s =>
            s.UserId == id && s.ExpiryTime > DateTime.UtcNow
        );

        var recent = await context
            .ActivityLogs.AsNoTracking()
            .Where(a => a.ActorUserId == id)
            .OrderByDescending(a => a.CreatedAt)
            .Take(10)
            .ToListAsync();

        return Ok(
            new
            {
                id = user.Id,
                username = user.Login,
                email = user.Mail,
                role = AppRoles.Normalize(user.Role),
                isBanned = user.Ban == 1,
                otdelId = user.OtdelId,
                otdel = user.Otdel?.NameOtd,
                tabel = user.Tabel,
                isOnline = presence.OnlineUserIds().Contains(user.Id),
                fio = worker?.Fio,
                doljnost = worker?.Doljnost,
                comeDate = user.ComeDate,
                banDate = user.BanDate,
                banComment = user.BanComment,
                banAmount = (int)user.BanAmount,
                activeSessions,
                recentActivity = recent.Select(a => new
                {
                    id = a.Id,
                    action = a.Action,
                    title = a.Title,
                    subtitle = a.Subtitle,
                    // Как в ActivityController — чтобы время в журнале и в карточке совпадало.
                    createdAt = a.CreatedAt.Kind == DateTimeKind.Unspecified
                        ? DateTime.SpecifyKind(a.CreatedAt, DateTimeKind.Utc)
                        : a.CreatedAt,
                }),
            }
        );
    }

    [HttpPut("{id:int}/role")]
    public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequest request)
    {
        if (request is null || string.IsNullOrWhiteSpace(request.Role))
            return BadRequest(new { message = "Роль не указана" });

        if (!AppRoles.All.Contains(request.Role))
            return BadRequest(new { message = "Недопустимая роль в системе" });

        if (IsSelf(id))
            return BadRequest(new { message = "Нельзя изменить собственную роль" });

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        if (!CanManage(user) || !CanAssign(request.Role))
            return NoRights();

        var oldRole = AppRoles.Normalize(user.Role);
        if (oldRole == request.Role)
            return Ok(new { message = "Роль не изменилась" });

        user.Role = request.Role;

        activityLog.Log(
            "role_changed",
            $"Изменена роль пользователя {user.Login}",
            $"{oldRole} → {request.Role}",
            CurrentUserId
        );

        await context.SaveChangesAsync();

        // Уже открытым подключениям — новые группы; самому пользователю — сигнал обновить токен.
        await notifier.SyncUserGroupsAsync(user.Id, request.Role);
        await notifier.NotifyAuthChangedAsync(user.Id, "role", request.Role);

        return Ok(new { message = $"Роль пользователя {user.Login} успешно изменена на {request.Role}" });
    }

    [HttpPut("{id:int}/profile")]
    public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateUserProfileRequest request)
    {
        var login = request?.Login?.Trim();
        if (string.IsNullOrEmpty(login))
            return BadRequest(new { message = "Логин не может быть пустым" });

        var mail = string.IsNullOrWhiteSpace(request!.Mail) ? null : request.Mail.Trim();
        if (mail is not null && !mail.Contains('@'))
            return BadRequest(new { message = "Некорректный email" });

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        if (!IsSelf(id) && !CanManage(user))
            return NoRights();

        if (request.OtdelId is int otdelId && !await context.Otdels.AnyAsync(o => o.Id == otdelId))
            return BadRequest(new { message = "Отдел не найден" });

        if (await context.Users.AnyAsync(u => u.Login == login && u.Id != id))
            return BadRequest(new { message = "Этот логин уже занят" });

        var changes = new List<string>();
        if (user.Login != login) changes.Add($"логин: {user.Login} → {login}");
        if (user.Mail != mail) changes.Add($"email: {user.Mail ?? "—"} → {mail ?? "—"}");
        if (user.OtdelId != request.OtdelId) changes.Add("отдел");

        if (changes.Count == 0)
            return Ok(new { message = "Изменений нет" });

        user.Login = login;
        user.Mail = mail;
        user.OtdelId = request.OtdelId;

        activityLog.Log(
            "user_profile_updated",
            $"Изменён профиль пользователя {user.Login}",
            string.Join(", ", changes),
            CurrentUserId
        );

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
        {
            return BadRequest(new { message = "Этот логин уже занят" });
        }

        await notifier.NotifyAuthChangedAsync(user.Id, "profile");

        return Ok(new { message = "Профиль обновлён" });
    }

    [HttpPost("{id:int}/ban")]
    public async Task<IActionResult> Ban(int id, [FromBody] BanUserRequest request)
    {
        var comment = request?.Comment?.Trim();
        if (string.IsNullOrEmpty(comment))
            return BadRequest(new { message = "Укажите причину блокировки" });

        if (comment.Length > MaxBanCommentLength)
            return BadRequest(new { message = $"Причина не длиннее {MaxBanCommentLength} символов" });

        if (IsSelf(id))
            return BadRequest(new { message = "Нельзя заблокировать самого себя" });

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        if (!CanManage(user))
            return NoRights();

        if (user.Ban == 1)
            return BadRequest(new { message = "Пользователь уже заблокирован" });

        user.Ban = 1;
        user.BanDate = BishkekClock.Now;
        user.BanComment = comment;
        user.BanAmount = (sbyte)Math.Min(user.BanAmount + 1, sbyte.MaxValue);

        await RemoveSessionsAsync(user.Id);

        activityLog.Log("user_banned", $"Заблокирован пользователь {user.Login}", comment, CurrentUserId);

        await context.SaveChangesAsync();
        await notifier.ForceLogoutAsync(user.Id, "banned");

        return Ok(new { message = $"Пользователь {user.Login} заблокирован" });
    }

    [HttpPost("{id:int}/unban")]
    public async Task<IActionResult> Unban(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        if (!CanManage(user))
            return NoRights();

        if (user.Ban != 1)
            return BadRequest(new { message = "Пользователь не заблокирован" });

        user.Ban = 0;
        user.BanDate = null;
        user.BanComment = null;

        activityLog.Log("user_unbanned", $"Разблокирован пользователь {user.Login}", null, CurrentUserId);

        await context.SaveChangesAsync();

        return Ok(new { message = $"Пользователь {user.Login} разблокирован" });
    }

    [HttpPost("{id:int}/sessions/revoke")]
    public async Task<IActionResult> RevokeSessions(int id)
    {
        if (IsSelf(id))
            return BadRequest(new { message = "Свою сессию завершите через «Выйти»" });

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        if (!CanManage(user))
            return NoRights();

        await RemoveSessionsAsync(user.Id);

        activityLog.Log("sessions_revoked", $"Завершены сессии пользователя {user.Login}", null, CurrentUserId);

        await context.SaveChangesAsync();
        await notifier.ForceLogoutAsync(user.Id, "sessions");

        return Ok(new { message = "Сессии завершены" });
    }

    [HttpPost("{id:int}/password")]
    public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetUserPasswordRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.NewPassword) || request.NewPassword.Length < MinPasswordLength)
            return BadRequest(new { message = $"Пароль должен содержать минимум {MinPasswordLength} символов" });

        if (IsSelf(id))
            return BadRequest(new { message = "Свой пароль меняйте в профиле" });

        var user = await context.Users.FindAsync(id);
        if (user is null)
            return NotFound(new { message = "Пользователь не найден" });

        if (!CanManage(user))
            return NoRights();

        user.Password = passwordHasher.Hash(request.NewPassword);
        await RemoveSessionsAsync(user.Id);

        activityLog.Log("password_reset", $"Сброшен пароль пользователя {user.Login}", null, CurrentUserId);

        await context.SaveChangesAsync();
        await notifier.ForceLogoutAsync(user.Id, "password");

        return Ok(new { message = "Пароль изменён, сессии пользователя завершены" });
    }

    private async Task RemoveSessionsAsync(int userId)
    {
        var sessions = await context.UserSessions.Where(s => s.UserId == userId).ToListAsync();
        context.UserSessions.RemoveRange(sessions);
    }
}
