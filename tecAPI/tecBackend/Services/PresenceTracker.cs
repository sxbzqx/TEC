namespace tecBackend.Services;

/// <summary>Кто сейчас онлайн: userId → connectionId'ы SignalR (у одного пользователя может быть несколько вкладок).</summary>
public sealed class PresenceTracker
{
    private readonly object _gate = new();
    private readonly Dictionary<int, HashSet<string>> _connections = new();

    /// <returns>true, если это первое подключение пользователя (он только что появился в сети).</returns>
    public bool Add(int userId, string connectionId)
    {
        lock (_gate)
        {
            if (!_connections.TryGetValue(userId, out var set))
                _connections[userId] = set = new HashSet<string>();

            set.Add(connectionId);
            return set.Count == 1;
        }
    }

    /// <returns>true, если подключений не осталось (пользователь вышел из сети).</returns>
    public bool Remove(int userId, string connectionId)
    {
        lock (_gate)
        {
            if (!_connections.TryGetValue(userId, out var set))
                return false;

            set.Remove(connectionId);
            if (set.Count > 0)
                return false;

            _connections.Remove(userId);
            return true;
        }
    }

    public string[] GetConnections(int userId)
    {
        lock (_gate)
            return _connections.TryGetValue(userId, out var set) ? [.. set] : [];
    }

    public HashSet<int> OnlineUserIds()
    {
        lock (_gate)
            return [.. _connections.Keys];
    }
}
