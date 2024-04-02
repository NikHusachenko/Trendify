using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users").HasKey(user => user.Id);

        builder.Property(user => user.FirstName).IsRequired(true).HasMaxLength(63);
        builder.Property(user => user.LastName).IsRequired(true).HasMaxLength(63);
        builder.Property(user => user.MiddleName).IsRequired(false).HasMaxLength(63);
        builder.Property(user => user.Email).IsRequired(true).HasMaxLength(127);
        builder.Property(user => user.Phone).IsRequired(true).HasMaxLength(31);
        builder.Property(user => user.Login).IsRequired(true).HasMaxLength(63);
        builder.Property(user => user.HashedPassword).IsRequired(true);

    }
}