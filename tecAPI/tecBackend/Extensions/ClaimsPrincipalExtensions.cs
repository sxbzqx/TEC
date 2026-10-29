using System.Security.Claims;

namespace tecBackend.Extensions;

public static class ClaimsPrincipalExtensions
{
    /// <summary>
    /// Id пользователя из JWT. null, если claim отсутствует или не число
    /// (вместо 500 от int.Parse).
    /// </summary>
    public static int? GetUserId(this ClaimsPrincipal principal)
    {
        var raw = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                  ?? principal.FindFirst("sub")?.Value;

        return int.TryParse(raw, out var id) ? id : null;
    }
}