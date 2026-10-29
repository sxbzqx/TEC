using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            });

        services.AddAuthorization();

        return services;
    }
}