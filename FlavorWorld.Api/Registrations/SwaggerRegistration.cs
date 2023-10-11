namespace FlavorWorld.Api.Registrations;

public static class SwaggerSettingRegistration
{
    public static IServiceCollection SwaggerRegistration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "FlavorWorldAPI",
                Version = "v1",
                Description = "FlavorWorld DDD Project",
            });
        });
        return services;
    }

    public static WebApplication SwaggerRegistrationApp(this WebApplication app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "FlavorWorld API v1");
        });
        return app;
    }
}