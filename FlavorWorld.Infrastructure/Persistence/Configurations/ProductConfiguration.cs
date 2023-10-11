//ProductConfiguration
using FlavorWorld.Domain.Aggregates.ProductAggregate;
using FlavorWorld.Domain.Aggregates.ProductAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductTable(builder);
    }

    private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(TableNames.Product);

        builder.HasKey(p => p.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Id,
                value => ProductId.Create(value));

        builder.Property(p => p.Name).HasMaxLength(100);

        builder.Property(p => p.CreatedDate).HasDefaultValue(DateTime.Now);

        builder.Property(p => p.Price).IsRequired();

        builder.Property(p => p.ProductStatus).HasDefaultValue(ProductStatus.Unknown);

        builder.HasMany(p => p.ProductReview)
            .WithOne()
            .HasForeignKey(r => r.ProductId);
    }
}