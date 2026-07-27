namespace tecBackend.Dtos;

public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword,
    string? CurrentRefreshToken = null
);