namespace TemperatureSensor.Infrastructure.ServicesExtension;

public static class MethodsExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<TemperatureContext>(o =>
        {
            o.UseSqlite("Data Source=TemperatureCaptor.db");
        });
        services.AddScoped<ITemperatureService, TemperatureService>();

        return services;
    }
}