using System.Security.Cryptography;
using System.Text;

namespace tecBackend.Utils;

public static class RefreshTokenHasher
{
    public static string Hash(string refreshToken)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken.Trim()));
        return Convert.ToBase64String(bytes);
    }
}
