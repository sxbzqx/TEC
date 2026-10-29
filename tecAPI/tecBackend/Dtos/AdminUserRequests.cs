namespace tecBackend.Dtos;

/// <summary>Профиль целиком: null в Mail / OtdelId очищает значение.</summary>
public record UpdateUserProfileRequest(string? Login, string? Mail, int? OtdelId);

public record BanUserRequest(string? Comment);

public record ResetUserPasswordRequest(string? NewPassword);
