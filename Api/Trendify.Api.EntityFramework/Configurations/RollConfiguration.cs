using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class RollCofiguration : IEntityTypeConfiguration<RollEntity>
{
    public void Configure(EntityTypeBuilder<RollEntity> builder)
    {
        builder.ToTable("Rolls").HasKey(roll => roll.Id);

        builder.Property(roll => roll.Name).IsRequired(true).HasMaxLength(63);
        builder.Property(roll => roll.Description).IsRequired(true).HasMaxLength(250);
        builder.Property(roll => roll.Count).IsRequired(true);
        builder.Property(roll => roll.Color).IsRequired(true).HasMaxLength(40);
        builder.Property(roll => roll.RAL).IsRequired(true);

        builder
        .HasOne<PreparatoryWorkshopEntity>(roll => roll.PreparatoryWorkshop)
        .WithMany(pr => pr.Rolls)
        .HasForeignKey(roll => roll.PreparatoryWorkshopId);
    }
}