using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class PositionsConfiguration : IEntityTypeConfiguration<PositionsEntity>
{
    public void Configure(EntityTypeBuilder<PositionsEntity> builder)
    {
        builder.ToTable("Positions").HasKey(position => position.Id);

        builder.Property(position => position.Position).IsRequired(true).HasMaxLength(63);

        builder
        .HasOne<UserEntity>(position => position.User)
        .WithMany(user => user.Positions)
        .HasForeignKey(position => position.UserId);
    }
}