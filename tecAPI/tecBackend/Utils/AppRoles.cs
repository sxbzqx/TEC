namespace tecBackend.Utils;

public static class AppRoles
{
    public const string SuperAdmin = "SuperAdmin";
    public const string Admin = "Admin";
    public const string Worker = "Worker";
    public const string User = "User";
    public const string Guest = "Guest";

    public static readonly string[] All = [SuperAdmin, Admin, Worker, User, Guest];

    /// <summary>Пустая роль в БД трактуется как Worker — так же, как при выдаче токена.</summary>
    public static string Normalize(string? role) => string.IsNullOrWhiteSpace(role) ? Worker : role;

    public static bool IsStaff(string? role) => role is SuperAdmin or Admin;
}
