using FlavorWorld.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlavorWorld.Infrastructure.Registrations;

public static class DatabaseContextRegistration
{
    public static IServiceCollection DatabaseRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlavorWorldDbContext>(options =>
        {
            options.UseSqlServer(configuration["DbConnection"],
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(AssemblyReference.Assembly.GetName().Name); // !!!
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: System.TimeSpan.FromSeconds(30), null);
            });
        });

        var optionsBuilder = new DbContextOptionsBuilder<FlavorWorldDbContext>().UseSqlServer(configuration["DbConnection"]);
        using var dbContext = new FlavorWorldDbContext(optionsBuilder.Options);
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();

        return services;
    }
}