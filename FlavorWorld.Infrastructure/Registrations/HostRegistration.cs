using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace FlavorWorld.Infrastructure.Registrations;

public static class HostSettingRegistration
{
    public static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
        where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        var logger = services.GetRequiredService<ILogger<TContext>>();

        var context = services.GetRequiredService<TContext>();

        try
        {
            var retry = Polly.Policy.Handle<SqlException>()
                .WaitAndRetry(new TimeSpan[]
                {
                        TimeSpan.FromSeconds(3),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(8),
                });

            retry.Execute(() => InvokeSeeder(seeder, context, services));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "There is a mistake in migration {0}", typeof(TContext).Name);
        }
        return host;
    }
    private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services)
        where TContext : DbContext
    {
        context.Database.EnsureCreated();
        context.Database.Migrate();
        seeder(context, services);
    }
}