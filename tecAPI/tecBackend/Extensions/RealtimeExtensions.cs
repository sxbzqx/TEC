using tecBackend.Hubs;
using tecBackend.Services;

namespace tecBackend.Extensions;

public static class RealtimeExtensions
{
    public static IServiceCollection AddAppRealtime(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSignalR();

        services.AddSingleton<PresenceTracker>();
        services.AddSingleton<IUserAuthStateService, UserAuthStateService>();
        services.AddSingleton<IPortalNotifier, PortalNotifier>();
        services.AddSingleton<RealtimeSaveChangesInterceptor>();

        return services;
    }

    public static WebApplication MapAppHubs(this WebApplication app)
    {
        app.MapHub<PortalHub>(PortalHub.Path);
        return app;
    }
}
