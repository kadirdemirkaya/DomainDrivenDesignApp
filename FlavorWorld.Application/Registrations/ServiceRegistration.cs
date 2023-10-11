using FlavorWorld.Application.Common.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Application.Registrations;

public static class ServiceSettingRegistration
{
    public static IServiceCollection ServiceRegistration(this IServiceCollection services)
    {
        services.AddHostedService<EmailSendService>();

        return services;
    }
}