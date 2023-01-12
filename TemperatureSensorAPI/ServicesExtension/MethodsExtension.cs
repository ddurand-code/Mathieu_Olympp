using Microsoft.OpenApi.Models;

namespace TemperatureSensorAPI.ServicesExtension;

public static class MethodsExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();

        services.AddGlobalExceptionHandling();

        services.AddControllers();

        services.AddInfrastructure();

        services.AddApplication();

        var contact = new OpenApiContact()
        {
            Name = "Mathieu Dupleix",
            Email = "mathieu.dupleix@olympp.fr",
            Url = new Uri("http://olympp.fr")
        };

        var license = new OpenApiLicense()
        {
            Name = "Free License",
            Url = new Uri("http://olympp.fr")
        };

        var info = new OpenApiInfo()
        {
            Version = "v1",
            Title = "Temperature Sensor",
            Description = "Un capteur de temperature avec son historique",
            TermsOfService = new Uri("http://olympp.fr"),
            Contact = contact,
            License = license
        };

        services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", info);
        });

        services.AddMemoryCache();

        return services;
    }
}