namespace tecBackend.Utils;

/// <summary>
/// Бишкекское время (Asia/Bishkek). Фиксированный сдвиг UTC+6 — Кыргызстан
/// не переходит на летнее время, поэтому просто прибавляем 6 часов к UTC.
/// Используем это вместо DateTime.UtcNow/DateTime.Now везде, где время потом
/// показывается пользователю (даты заявок, новостей, ленты активности),
/// чтобы не зависеть от часового пояса сервера и не путать UTC с локальным.
/// </summary>
public static class BishkekClock
{
    /// <summary>
    /// Kind явно сбрасывается на Unspecified: иначе System.Text.Json допишет
    /// к дате суффикс "Z" (т.к. DateTime.UtcNow.AddHours сохраняет Kind=Utc),
    /// фронт примет уже бишкекское время за UTC и сдвинет его ещё раз под
    /// часовой пояс браузера.
    /// </summary>
    public static DateTime Now => DateTime.SpecifyKind(DateTime.UtcNow.AddHours(6), DateTimeKind.Unspecified);
}
