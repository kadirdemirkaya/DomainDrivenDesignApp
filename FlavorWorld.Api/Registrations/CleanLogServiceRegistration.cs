using FlavorWorld.Application.Services;

namespace FlavorWorld.Api.Registrations;

public static class CleanLogSettingServiceRegistration
{
    public static IServiceCollection CleanLogService(this IServiceCollection services)
    {
        services.AddHostedService<LogCleanupService>();

        return services;
    }
}