namespace tecBackend.Dtos;

/// <summary>
/// Регистрация обычного пользователя (не сотрудника ТЭЦ) — без привязки к отделу.
/// </summary>
public record RegisterRequest(string Login, string Password, string? Mail);
