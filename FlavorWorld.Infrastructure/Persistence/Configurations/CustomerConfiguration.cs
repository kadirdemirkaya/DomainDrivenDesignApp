using FlavorWorld.Domain.Aggregates.CustomerAggregate;
using FlavorWorld.Domain.Aggregates.CustomerAggregate.Enums;
using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ConfigureCustomerTable(builder);
    }

    private void ConfigureCustomerTable(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(TableNames.Customer);

        builder.HasKey(c => c.Id);

        builder.Property(m => m.Id)
          .ValueGeneratedNever()
          .HasConversion(
              id => id.Id,
              value => CustomerId.Create(value));

        builder.Property(m => m.UserId)
            .HasConversion(
                id => id.Id,
                value => UserId.Create(value));

        builder.Property(c => c.CreatedDate)
               .HasDefaultValue(DateTime.Now);

        builder.Property(c => c.FirstName)
               .HasMaxLength(100)
               .HasDefaultValue(null);

        builder.Property(c => c.LastName)
               .HasMaxLength(100)
               .HasDefaultValue(null);

        builder.Property(c => c.Gender)
               .HasDefaultValue(GenderStatus.Unknown);

        builder.Property(c => c.PhoneNumber);

        // builder.OwnsOne(
        //    p => p.Address,
        //    addressNBuilder =>
        //    {
        //        addressNBuilder.ToTable(TableNames.Address);

        //        addressNBuilder.WithOwner().HasForeignKey(nameof(CustomerId));

        //        addressNBuilder.Property<Guid>(ColumnNames.Id); //!!!!!!!!!!!!!!!!!!

        //        addressNBuilder.HasKey(ColumnNames.Id); //!!!!!!!!!!!!!!!!!!

        //        addressNBuilder.Property(c => c.City).IsRequired().HasMaxLength(100);

        //        addressNBuilder.Property(c => c.Country).IsRequired().HasMaxLength(100);

        //        addressNBuilder.Property(c => c.FullAddress).IsRequired().HasMaxLength(100);

        //        addressNBuilder.Property(c => c.Street).IsRequired().HasMaxLength(100);
        //    }
        // );

        // builder.HasOne(c => c.User)
        //     .WithOne(u => u.Customer)
        //     .HasForeignKey<Customer>(c => c.UserId);
    }
}