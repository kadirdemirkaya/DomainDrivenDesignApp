using FlavorWorld.Contracts.Options;

namespace FlavorWorld.Api.Registrations;

public static class OptionsSettingRegistration
{
    public static WebApplicationBuilder OptionsRegistration(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<DbConnectionString>(builder.Configuration.GetSection("DbConnectionString"));

        builder.Services.Configure<RedisConnectionString>(builder.Configuration.GetSection("RedisConnectionString"));

        return builder;
    }
}