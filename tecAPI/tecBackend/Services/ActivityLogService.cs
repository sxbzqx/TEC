namespace tecBackend.Services;

using tecBackend.Utils;

public class ActivityLogService : IActivityLogService
{
    private readonly tecBackend.Models.SiteContext _context;
 
    public ActivityLogService(tecBackend.Models.SiteContext context)
    {
        _context = context;
    }
 
    public void Log(string action, string title, string? subtitle = null, int? actorUserId = null)
    {
        _context.ActivityLogs.Add(
            new Models.ActivityLog
            {
                Action = action,
                Title = title,
                Subtitle = subtitle,
                ActorUserId = actorUserId,
                CreatedAt = BishkekClock.Now,
            }
        );
    }
}