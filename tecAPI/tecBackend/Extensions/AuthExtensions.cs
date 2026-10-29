using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using tecBackend.Hubs;
using tecBackend.Services;

namespace tecBackend.Extensions;

public static class AuthExtensions
{
    public static IServiceCollection AddAppJwtAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var secret = configuration["AppSettings:Token"]
            ?? throw new InvalidOperationException("Ключа JWT нет в конфигурации");

        var issuer = configuration["AppSettings:Issuer"] ?? "tec-api";
        var audience = configuration["AppSettings:Audience"] ?? "tec-client";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    NameClaimType = ClaimTypes.Name,
                    RoleClaimType = ClaimTypes.Role,
                };

                options.Events = new JwtBearerEvents
                {
                    // WebSocket не умеет слать заголовок Authorization — SignalR передаёт токен в query.
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        if (
                            !string.IsNullOrEmpty(accessToken)
                            && context.HttpContext.Request.Path.StartsWithSegments(PortalHub.Path)
                        )
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    },

                    // Подпись и срок токена уже проверены. Дальше сверяем с БД: роль в токене должна
                    // совпадать с текущей, пользователь не должен быть заблокирован или удалён.
                    // Иначе 401 — клиент сам обновит токен через /auth/refresh и получит новую роль.
                    OnTokenValidated = async context =>
                    {
                        var principal = context.Principal;
                        var userId = principal?.GetUserId();

                        if (principal is null || userId is null)
                        {
                            context.Fail("Токен без идентификатора пользователя");
                            return;
                        }

                        var states = context.HttpContext.RequestServices.GetRequiredService<IUserAuthStateService>();
                        var state = await states.GetAsync(userId.Value, context.HttpContext.RequestAborted);
                        var tokenRole = principal.FindFirst(ClaimTypes.Role)?.Value;

                        if (state is null || state.IsBanned)
                        {
                            context.Fail("Пользователь не найден или заблокирован");
                        }
                        else if (!string.Equals(state.Role, tokenRole, StringComparison.Ordinal))
                        {
                            context.HttpContext.Items[PortalHubItems.StaleToken] = true;
                            context.Fail("Роль в токене устарела");
                        }
                    },
                };
            });

        services.AddAuthorization();

        return services;
    }
}