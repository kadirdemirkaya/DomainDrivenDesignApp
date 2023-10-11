using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Application.Registrations;

public static class MapperSettingRegistration
{
    public static IServiceCollection MapperRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(Application.AssemblyReference.Assembly);

        return services;
    }
}