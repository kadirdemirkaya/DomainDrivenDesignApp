using FlavorWorld.Infrastructure.Health;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FlavorWorld.Infrastructure.Registrations;

public static class HealtCheckSettingRegistration
{
    public static IServiceCollection HealtCheckRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddCheck<DatabaseHealthCheck>("sqlserver_database_check")
            .AddCheck<ElasticSearchCheck>("elastic_search_check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "elasticsearch" })
            .AddCheck<LogHealthCheck>("log_health_check", failureStatus: HealthStatus.Unhealthy, tags: new[] { "serilog" })
            .AddRedis(configuration["RedisConfig:ConnectionString"]!);
        //.AddSqlServer(DatabaseConfiguration.ConnectionString, "sql_server_check");
        //.AddSqlServer(
        //     connectionString: configuration["DbConnectionString:DbConnection"]!,
        //     failureStatus: HealthStatus.Unhealthy,
        //     healthQuery: "SELECT 1",
        //     name: "SqlServer connection",
        //     tags: new[] { "sqlserver" }
        // );
        return services;
    }
    public static WebApplication HealtCheckRegistrationApp(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        });
        return app;
    }
}