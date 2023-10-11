using System.Text.Json.Serialization;
using FlavorWorld.Api.Filters;

namespace FlavorWorld.Api.Registrations;

public static class CorsSettingRegistration
{
    public static IServiceCollection CorsRegistration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin",
                builder =>
                {
                    builder.WithOrigins("https://localhost:7265")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });

        return services;
    }

    public static WebApplication CorsRegistrationApp(this WebApplication app)
    {
        app.UseCors("AllowOrigin");
        return app;
    }
}