using FlavorWorld.Application.Registrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.MediatrRegistration()
                .MapperRegistration()
                .ServiceRegistration();

        return services;
    }

    public static WebApplication AddApplicationApp(this WebApplication app)
    {

        return app;
    }
}