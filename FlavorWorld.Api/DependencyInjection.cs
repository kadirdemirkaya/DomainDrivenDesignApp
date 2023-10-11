using FlavorWorld.Api.Registrations;

namespace FlavorWorld.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.FluentValidationRegistration()
                .LogRegistration(configuration)
                .ControllerRegistration()
                .CorsRegistration()
                .SwaggerRegistration()
                .CleanLogService();

        return services;
    }

    public static WebApplication AddPresentationApp(this WebApplication app)
    {
        app.ConfigureExceptionHandler();

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseFluentValidationException();

        app.LogRegistrationApp();

        app.CorsRegistrationApp();

        app.SwaggerRegistrationApp();

        return app;
    }
}