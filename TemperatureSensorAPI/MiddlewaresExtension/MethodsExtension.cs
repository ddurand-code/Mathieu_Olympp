namespace TemperatureSensorAPI.MiddlewaresExtension;

public static class MethodsExtension
{
    public static IServiceCollection AddGlobalExceptionHandling(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandling>();
        return services;
    }
    public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandling>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        return app;
    }
}