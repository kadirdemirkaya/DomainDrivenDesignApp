using FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;
using FlavorWorld.Domain.Joins;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class UserRoleConfigurations : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        ConfigureUserRoleTable(builder);
    }

    private void ConfigureUserRoleTable(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(TableNames.UserRole);

        builder.HasKey(x => new { x.RoleId, x.UserId });

        builder.Property(m => m.UserId)
            .HasConversion(
                id => id.Id,
                value => UserId.Create(value));
    }
}
