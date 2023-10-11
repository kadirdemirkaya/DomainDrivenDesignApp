using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Application.Registrations;

public static class DatabaseSettingRegistration
{
    public static IServiceCollection MediatrRegistration(this IServiceCollection services)
    {
        services.AddMediatR(AssemblyReference.Assembly);

        return services;
    }
}