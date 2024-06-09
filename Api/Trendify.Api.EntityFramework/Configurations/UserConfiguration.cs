using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users").HasKey(user => user.Id);

        builder.HasOne<WorkshopEntity>(user => user.Workshop)
            .WithMany(workshop => workshop.Users)
            .HasForeignKey(user => user.WorkshopId);

        builder.HasOne<CredentialsEntity>(user => user.Credentials)
            .WithOne(credentials => credentials.User)
            .HasForeignKey<UserEntity>(user => user.CredentialsId);
    }
}