using FlavorWorld.Domain.Abstractions.Common;
using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Domain.Enumerations;
using FlavorWorld.Domain.Joins;
using FlavorWorld.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace FlavorWorld.Infrastructure.Persistence.Data;

public class FlavorWorldDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptors _publishDomainEventsInterceptors;


    public FlavorWorldDbContext(DbContextOptions options, PublishDomainEventsInterceptors publishDomainEventsInterceptors) : base(options)
    {
        _publishDomainEventsInterceptors = publishDomainEventsInterceptors;
    }

    public FlavorWorldDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; private set; }
    public DbSet<Order> Order { get; private set; }
    public DbSet<OrderItem> OrderItem { get; private set; }
    public DbSet<Product> Product { get; private set; }
    public DbSet<ProductReview> ProductReview { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<Role> Roles { get; private set; }
    public DbSet<UserRole> UserRole { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<List<IDomainEvent>>();//not include db
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptors);
        base.OnConfiguring(optionsBuilder);
    }
}