namespace tecBackend.Extensions;

public static class CorsExtensions
{
    public const string PolicyName = "AllowNextJS";

    public static IServiceCollection AddAppCors(this IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddPolicy(PolicyName, policy => policy
                .SetIsOriginAllowed(IsAllowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));

        return services;
    }

    private static bool IsAllowedOrigin(string origin)
    {
        if (!Uri.TryCreate(origin, UriKind.Absolute, out var uri))
            return false;

        return uri.Host.StartsWith("10.0.4.")
            || uri.Host == "localhost"
            || uri.Host == "btec.kg";
    }
}