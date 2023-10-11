using FlavorWorld.Infrastructure.Persistence.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Infrastructure.Registrations;

public static class InterceptorsSettingRegistration
{
    public static IServiceCollection InterceptorsRegistration(this IServiceCollection services)
    {
        services.AddScoped<PublishDomainEventsInterceptors>();

        return services;
    }
}