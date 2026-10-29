using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using tecBackend.Models;
using tecBackend.Utils;

namespace tecBackend.Services;

public sealed record UserAuthState(string Role, bool IsBanned);

/// <summary>
/// Актуальные роль и бан пользователя из БД (с коротким кэшем). Нужен, чтобы JWT, выданный
/// до смены роли или блокировки, переставал работать сразу, а не через 30 минут.
/// Кэш сбрасывается из <see cref="RealtimeSaveChangesInterceptor"/> при любом сохранении User.
/// </summary>
public interface IUserAuthStateService
{
    Task<UserAuthState?> GetAsync(int userId, CancellationToken ct = default);

    void Invalidate(int userId);
}

public sealed class UserAuthStateService(IMemoryCache cache, IServiceScopeFactory scopes) : IUserAuthStateService
{
    private static readonly TimeSpan Ttl = TimeSpan.FromMinutes(2);

    private static string Key(int userId) => $"auth-state:{userId}";

    public async Task<UserAuthState?> GetAsync(int userId, CancellationToken ct = default)
    {
        return await cache.GetOrCreateAsync(
            Key(userId),
            async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = Ttl;

                using var scope = scopes.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<SiteContext>();

                var row = await db
                    .Users.AsNoTracking()
                    .Where(u => u.Id == userId)
                    .Select(u => new { u.Role, u.Ban })
                    .FirstOrDefaultAsync(ct);

                return row is null ? null : new UserAuthState(AppRoles.Normalize(row.Role), row.Ban == 1);
            }
        );
    }

    public void Invalidate(int userId) => cache.Remove(Key(userId));
}
