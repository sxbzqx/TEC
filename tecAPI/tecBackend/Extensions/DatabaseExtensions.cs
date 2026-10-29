using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using tecBackend.Models;

namespace tecBackend.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddAppDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddDbContext<SiteContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .ConfigureWarnings(w =>
                    w.Ignore(RelationalEventId.PendingModelChangesWarning)));

        return services;
    }
}