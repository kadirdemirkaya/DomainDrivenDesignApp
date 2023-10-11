using FlavorWorld.Domain.Aggregates.Order.ValueObjects;
using FlavorWorld.Domain.Aggregates.OrderAggregate.Entities;
using FlavorWorld.Domain.Aggregates.OrderAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        ConfigureOrderItemTable(builder);
    }

    public static void ConfigureOrderItemTable(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable(TableNames.OrderItem);

        builder.HasKey(o => o.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Id,
                value => OrderItemId.Create(value));

        builder.Property(m => m.ProductId)
            .HasConversion(
                id => id.Id,
                value => ProductId.Create(value));

        builder.Property(m => m.OrderId)
            .HasConversion(
                id => id.Id,
                value => OrderId.Create(value));

        builder.Property(oi => oi.CreateDate).HasDefaultValue(DateTime.Now);

        builder.Property(oi => oi.Quantity).IsRequired();

        builder.HasOne(o => o.Product)
            .WithMany()
            .HasForeignKey(p => p.ProductId);
    }
}