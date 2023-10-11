using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrderTable(builder);
    }

    private void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(TableNames.Order);

        builder.HasKey(o => o.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Id,
                value => OrderId.Create(value));

        builder.Property(m => m.UserId)
            .HasConversion(
                id => id.Id,
                value => UserId.Create(value));

        builder.Property(o => o.Description).HasMaxLength(100);

        builder.Property(o => o.CreatedDate).HasDefaultValue(DateTime.Now);

        builder.HasMany(o => o.OrderItems)
           .WithOne()
           .HasForeignKey(oi => oi.OrderId);
    }
}