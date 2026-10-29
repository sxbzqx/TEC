using System.Net;
using Microsoft.AspNetCore.HttpOverrides;

namespace tecBackend.Extensions;

public static class ForwardedHeadersExtensions
{
    // Нужен, если API стоит за nginx/IIS: иначе RemoteIpAddress = адрес прокси,
    // и rate limiting по IP снова схлопывается в один счётчик.
    // Адреса прокси: ForwardedHeaders:KnownProxies (в env: ForwardedHeaders__KnownProxies__0=10.0.4.1)
    public static IServiceCollection AddAppForwardedHeaders(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var proxies = configuration.GetSection("ForwardedHeaders:KnownProxies").Get<string[]>() ?? [];

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

            foreach (var proxy in proxies)
            {
                if (IPAddress.TryParse(proxy, out var ip))
                    options.KnownProxies.Add(ip);
            }
        });

        return services;
    }
}