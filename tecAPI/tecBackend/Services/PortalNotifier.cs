using Microsoft.AspNetCore.SignalR;
using tecBackend.Hubs;
using tecBackend.Utils;

namespace tecBackend.Services;

/// <summary>Темы, по которым клиент перезапрашивает данные. Должны совпадать с tec_client/utils/realtime.ts.</summary>
public static class RealtimeTopics
{
    public const string Posts = "posts";
    public const string Categories = "categories";
    public const string Activity = "activity";
    public const string Departments = "departments";
    public const string Bids = "bids";
    public const string Resources = "resources";
    public const string Equipment = "equipment";
    public const string Workers = "workers";
    public const string Users = "users";
    public const string Suggestions = "suggestions";

    // Публичные данные — слушают все, включая гостей.
    private static readonly HashSet<string> Public = [Posts, Categories, Departments];

    // Персональные данные сотрудников и список аккаунтов — только админам.
    private static readonly HashSet<string> StaffOnly = [Workers, Users];

    public static bool IsPublic(string topic) => Public.Contains(topic);

    public static bool IsStaffOnly(string topic) => StaffOnly.Contains(topic);
}

public interface IPortalNotifier
{
    /// <summary>Сообщить клиентам, что данные по темам изменились (в событии только имя темы, без данных).</summary>
    Task PublishDataChangedAsync(IEnumerable<string> topics);

    /// <summary>Сообщить пользователю, что его роль/профиль изменились (reason: role | profile).</summary>
    Task NotifyAuthChangedAsync(int userId, string reason, string? role = null);

    /// <summary>Принудительно разлогинить пользователя на всех устройствах (reason: banned | sessions | password).</summary>
    Task ForceLogoutAsync(int userId, string reason);

    /// <summary>Перевыдать группы уже открытым подключениям пользователя после смены роли.</summary>
    Task SyncUserGroupsAsync(int userId, string role);
}

public sealed class PortalNotifier(
    IHubContext<PortalHub> hub,
    PresenceTracker presence,
    ILogger<PortalNotifier> logger
) : IPortalNotifier
{
    public async Task PublishDataChangedAsync(IEnumerable<string> topics)
    {
        foreach (var topic in topics)
        {
            IClientProxy audience =
                RealtimeTopics.IsPublic(topic) ? hub.Clients.All
                : RealtimeTopics.IsStaffOnly(topic) ? hub.Clients.Group(PortalGroups.Staff)
                : hub.Clients.Group(PortalGroups.Members);

            await SafeSendAsync(audience, PortalEvents.DataChanged, topic);
        }
    }

    public Task NotifyAuthChangedAsync(int userId, string reason, string? role = null) =>
        SafeSendAsync(hub.Clients.User(userId.ToString()), PortalEvents.AuthChanged, new { reason, role });

    public Task ForceLogoutAsync(int userId, string reason) =>
        SafeSendAsync(hub.Clients.User(userId.ToString()), PortalEvents.ForceLogout, new { reason });

    public async Task SyncUserGroupsAsync(int userId, string role)
    {
        var isStaff = AppRoles.IsStaff(role);

        foreach (var connectionId in presence.GetConnections(userId))
        {
            try
            {
                if (isStaff)
                    await hub.Groups.AddToGroupAsync(connectionId, PortalGroups.Staff);
                else
                    await hub.Groups.RemoveFromGroupAsync(connectionId, PortalGroups.Staff);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Не удалось обновить группы подключения {ConnectionId}", connectionId);
            }
        }
    }

    // Realtime — вторичный канал: его сбой не должен ломать основную операцию.
    private async Task SafeSendAsync(IClientProxy proxy, string method, object? arg)
    {
        try
        {
            await proxy.SendAsync(method, arg);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "SignalR: не удалось отправить {Method}", method);
        }
    }
}