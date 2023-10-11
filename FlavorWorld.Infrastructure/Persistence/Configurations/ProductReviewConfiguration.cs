using FlavorWorld.Domain.Aggregates.ProductAggregate.Entities;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        ConfigureProductReviewTable(builder);
    }

    private void ConfigureProductReviewTable(EntityTypeBuilder<ProductReview> builder)
    {
        builder.ToTable(TableNames.ProductReview);

        builder.HasKey(r => r.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Id,
                value => ProductReviewId.Create(value));

        builder.Property(m => m.ProductId)
            .HasConversion(
                id => id.Id,
                value => ProductId.Create(value));

        builder.Property(pr => pr.CreatedDate).HasDefaultValue(DateTime.Now);

        builder.Property(pr => pr.ProductName).HasMaxLength(100);

        builder.Property(pr => pr.Stars).IsRequired();
    }
}