namespace tecBackend.Services;

public interface IActivityLogService
{
    void Log(string action, string title, string? subtitle = null, int? actorUserId = null);
}
