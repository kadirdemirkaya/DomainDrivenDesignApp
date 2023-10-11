using FlavorWorld.Infrastructure.Persistence.Data;
using FlavorWorld.Infrastructure.Persistence.Seeds;
using FlavorWorld.Infrastructure.Registrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FlavorWorld.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.DatabaseRegistrations(configuration)
            .RepositoryRegistration()
            .InterceptorsRegistration()
            .ServiceRegistration()
            .JsonWebTokenRegistration()
            .RedisRegistration(configuration)
            .ElasticsearchRegistration(configuration)
            .HealtCheckRegistration(configuration);

        return services;
    }

    public static IApplicationBuilder AddInfrastructureApp(this WebApplication app, IConfiguration configuration)
    {
        app.HealtCheckRegistrationApp();

        app.ElasticsearchRegistrationApp(configuration);

        app.MigrateDbContext<FlavorWorldDbContext>(async (context, serviceProvider) =>
        {
            var services = app.Services;
            var logger = services.GetService<ILogger<FlavorWorldDbContext>>();

            var dbContextSeed = new FlavorWorldDbContextSeed();
            dbContextSeed.SeedAsync(context, logger!).GetAwaiter();
        });


        return app;
    }

    public static WebApplicationBuilder AddInfrastructureBuilder(this WebApplicationBuilder builder)
    {
        builder.ElasticsearchRegistrationBuilder();
        return builder;
    }
}