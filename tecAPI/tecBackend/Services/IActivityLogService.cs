namespace tecBackend.Services;

public interface IActivityLogService
{
    /// <summary>
    /// Добавляет запись в контекст БЕЗ вызова SaveChanges — она сохранится
    /// вместе с основной операцией контроллера (CreatePost, UpdateUserRole и т.д.)
    /// при их собственном await _context.SaveChangesAsync(). Это гарантирует,
    /// что событие не запишется, если основная операция провалится.
    /// </summary>
    void Log(string action, string title, string? subtitle = null, int? actorUserId = null);
}
