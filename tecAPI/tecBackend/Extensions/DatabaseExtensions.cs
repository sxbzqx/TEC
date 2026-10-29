using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using tecBackend.Models;
using tecBackend.Services;

namespace tecBackend.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddAppDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddDbContext<SiteContext>((sp, options) =>
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(sp.GetRequiredService<RealtimeSaveChangesInterceptor>())
                .ConfigureWarnings(w =>
                    w.Ignore(RelationalEventId.PendingModelChangesWarning)));

        return services;
    }
}