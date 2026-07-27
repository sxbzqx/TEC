using System.Security.Cryptography;
using System.Text;

namespace tecBackend.Utils;

/// <summary>
/// Refresh-токены уже криптографически случайны (64 байта из RandomNumberGenerator),
/// поэтому для их хранения достаточно быстрого детерминированного хэша (SHA-256) —
/// в отличие от паролей, здесь не нужен медленный хэш с солью: подобрать 64-байтовое
/// случайное значение перебором нереально, а детерминированность нужна, чтобы искать
/// сессию в БД по хэшу напрямую.
/// </summary>
public static class RefreshTokenHasher
{
    public static string Hash(string refreshToken)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken.Trim()));
        return Convert.ToBase64String(bytes);
    }
}
