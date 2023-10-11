using System.Text.Json.Serialization;
using FlavorWorld.Api.Filters;

namespace FlavorWorld.Api.Registrations;

public static class ControllerSettingRegistration
{
    public static IServiceCollection ControllerRegistration(this IServiceCollection services)
    {

        services.AddControllers(options =>
        {
            options.Filters.Add<ValidationFilter>();
        })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            })
            .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

        return services;
    }
}