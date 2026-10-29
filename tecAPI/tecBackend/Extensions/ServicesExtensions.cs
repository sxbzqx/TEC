using tecBackend.Services;

namespace tecBackend.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddMemoryCache();

        services.AddScoped<ITokenService, TokenService>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IActivityLogService, ActivityLogService>();
        services.AddScoped<OfficeEquipmentService>();
        services.AddScoped<IEmployeeVerificationService, EmployeeVerificationService>();

        return services;
    }
}