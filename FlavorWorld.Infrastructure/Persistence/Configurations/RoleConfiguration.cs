using FlavorWorld.Domain.Enumerations;
using FlavorWorld.Infrastructure.Persistence.StaticConstants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlavorWorld.Infrastructure.Persistence.Configurations;

public sealed class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        ConfigureRoleTable(builder);
    }

    private void ConfigureRoleTable(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames.Role);

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnType("UniqueIdentifier");

        builder.Property(r => r.Description).HasMaxLength(100);

        builder.Property(r => r.Name).HasMaxLength(100);

        builder.HasMany(r => r.Users)
           .WithMany(u => u.Roles);
    }
}
