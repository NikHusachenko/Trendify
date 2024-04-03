using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class CuttingConfiguration : IEntityTypeConfiguration<CuttingsEntity>
{
    public void Configure(EntityTypeBuilder<CuttingsEntity> builder)
    {
        builder.ToTable("Cuttings").HasKey(cut => cut.Id);

        builder.Property(cut => cut.Name).IsRequired(true).HasMaxLength(63);
        builder.Property(cut => cut.Description).IsRequired(true).HasMaxLength(250);
        builder.Property(cut => cut.Count).IsRequired(true);
        builder.Property(cut => cut.Color).IsRequired(true).HasMaxLength(40);
        builder.Property(cut => cut.RAL).IsRequired(true);
        builder.Property(cut => cut.CuttingType).IsRequired(true).HasConversion<int>();

        builder
        .HasOne<CuttingWorkshopEntity>(cut => cut.CuttingWorkshop)
        .WithMany(cw => cw.Cuttings)
        .HasForeignKey(cut => cut.CuttingWorkshop);
    }
}