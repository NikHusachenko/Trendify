using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Roles").HasKey(role => role.Id);

        builder.Property(role => role.Name).IsRequired(true).HasMaxLength(63);
    }
}