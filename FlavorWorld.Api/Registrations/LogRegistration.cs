using FlavorWorld.StaticConstants;
using Serilog;

namespace FlavorWorld.Api.Registrations;

public static class LogSettingRegistration
{
    public static IServiceCollection LogRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        return services;
    }

    public static WebApplication LogRegistrationApp(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        return app;
    }
}