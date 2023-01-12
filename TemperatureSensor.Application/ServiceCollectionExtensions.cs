namespace TemperatureSensor.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssemblies(new List<Assembly>
        {
            typeof(ValidationBehavior<,>).Assembly,
            typeof(GetTemperatureQuery).Assembly,
            typeof(DTO.TemperatureDTO).Assembly,
        });
        return services;
    }
}