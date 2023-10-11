using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisCrudCommon.Extensions;

namespace FlavorWorld.Infrastructure.Registrations;

public static class RedisSettingRegistration
{
    public static IServiceCollection RedisRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRedisServices(conf => conf.RedisConnection = configuration["RedisConfig:ConnectionString"]!);

        return services;
    }
}