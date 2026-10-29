using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using tecBackend.Extensions;
using tecBackend.Services;
using tecBackend.Utils;

namespace tecBackend.Hubs;

public static class PortalGroups
{
    /// <summary>Все авторизованные подключения.</summary>
    public const string Members = "members";

    /// <summary>Admin / SuperAdmin.</summary>
    public const string Staff = "staff";
}

/// <summary>Имена событий, которые сервер шлёт клиентам.</summary>
public static class PortalEvents
{
    /// <summary>Данные темы изменились — клиенту нужно перезапросить связанные запросы.</summary>
    public const string DataChanged = "DataChanged";

    /// <summary>Права/профиль текущего пользователя изменились — обновить токен и интерфейс.</summary>
    public const string AuthChanged = "AuthChanged";

    /// <summary>Сессия завершена администратором — выйти из системы.</summary>
    public const string ForceLogout = "ForceLogout";

    /// <summary>Пользователь появился в сети / вышел (только для Staff).</summary>
    public const string PresenceChanged = "PresenceChanged";
}

/// <summary>
/// Один хаб на весь портал. Только сервер → клиент: методов, которые вызывает клиент, нет.
/// Подключаться можно и без токена (публичные новости), но тогда группы Members/Staff не выдаются.
/// </summary>
public class PortalHub(PresenceTracker presence) : Hub
{
    public const string Path = "/hubs/portal";

    public override async Task OnConnectedAsync()
    {
        var http = Context.GetHttpContext();

        if (Context.User?.GetUserId() is int userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, PortalGroups.Members);

            if (AppRoles.IsStaff(Context.User.FindFirstValue(ClaimTypes.Role)))
                await Groups.AddToGroupAsync(Context.ConnectionId, PortalGroups.Staff);

            if (presence.Add(userId, Context.ConnectionId))
                await Clients
                    .Group(PortalGroups.Staff)
                    .SendAsync(PortalEvents.PresenceChanged, new { userId, online = true });
        }
        else if (http?.Items.ContainsKey(PortalHubItems.StaleToken) == true)
        {
            // Токен подписан верно, но роль в нём устарела (роль поменяли, пока вкладка спала).
            // Просим клиента обновить токен и переподключиться.
            await Clients.Caller.SendAsync(PortalEvents.AuthChanged, new { reason = "stale" });
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (Context.User?.GetUserId() is int userId && presence.Remove(userId, Context.ConnectionId))
        {
            await Clients
                .Group(PortalGroups.Staff)
                .SendAsync(PortalEvents.PresenceChanged, new { userId, online = false });
        }

        await base.OnDisconnectedAsync(exception);
    }
}

public static class PortalHubItems
{
    public const string StaleToken = "portal:stale-token";
}
