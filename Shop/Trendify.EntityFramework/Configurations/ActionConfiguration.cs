using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class ActionConfiguration : IEntityTypeConfiguration<ActionEntity>
{
    public void Configure(EntityTypeBuilder<ActionEntity> builder)
    {
        builder.ToTable("Actions").HasKey(action => action.Id);

        builder.Property(action => action.Name).IsRequired(true).HasMaxLength(511);

        builder.HasOne<UserEntity>(action => action.User)
            .WithMany(user => user.Actions)
            .HasForeignKey(action => action.UserId);
    }
}