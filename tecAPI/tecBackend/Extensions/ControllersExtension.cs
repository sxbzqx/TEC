using System.Text.Json.Serialization;

namespace tecBackend.Extensions;

public static class ControllersExtensions
{
    public static IServiceCollection AddAppControllers(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        return services;
    }
}