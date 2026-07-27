namespace tecBackend.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool IsHashed(string storedPassword)
    {
        return !string.IsNullOrEmpty(storedPassword)
            && storedPassword.Length == 60
            && (
                storedPassword.StartsWith("$2a$")
                || storedPassword.StartsWith("$2b$")
                || storedPassword.StartsWith("$2y$")
            );
    }

    public bool Verify(string password, string storedPassword)
    {
        if (IsHashed(storedPassword))
            return BCrypt.Net.BCrypt.Verify(password, storedPassword);

        return storedPassword == password;
    }
}