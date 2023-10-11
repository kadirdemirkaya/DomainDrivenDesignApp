using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Aggregates.UserAggregate;
using FlavorWorld.Domain.Aggregates.UserAggregate.Enums;
using FlavorWorld.Domain.Enumerations;
using FlavorWorld.Domain.Joins;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
    }

    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.User);

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Id,
                value => UserId.Create(value));

        builder.Property(u => u.CreatedDate).HasDefaultValue(DateTime.Now);

        builder.Property(u => u.Email).IsRequired();

        builder.Property(u => u.Password).IsRequired();

        builder.Property(u => u.Username).HasMaxLength(100).IsRequired();

        builder.Property(u => u.UserStatus).HasDefaultValue(UserStatus.Offline);

        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .UsingEntity<UserRole>();

        // builder.HasOne(u => u.Customer)
        //     .WithOne(c => c.User)
        //     .HasForeignKey<User>(u => u.CustomerId);
    }
}