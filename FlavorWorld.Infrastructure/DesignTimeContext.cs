using FlavorWorld.Infrastructure.Configurations;
using FlavorWorld.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FlavorWorld.Infrastructure;

public class DesignTimeContext : IDesignTimeDbContextFactory<FlavorWorldDbContext>
{
    public FlavorWorldDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<FlavorWorldDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}