using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class UserRolesConfiguration : IEntityTypeConfiguration<UserRolesEntity>
{
    public void Configure(EntityTypeBuilder<UserRolesEntity> builder)
    {
        builder.ToTable("User roles").HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasOne<UserEntity>(ur => ur.User)
            .WithMany(user => user.Roles)
            .HasForeignKey(ur => ur.UserId);

        builder.HasOne<RoleEntity>(ur => ur.Role)
            .WithMany(role => role.Users)
            .HasForeignKey(ur => ur.RoleId);
    }
}