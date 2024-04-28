using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class MaterialWorkshopsConfiguration : IEntityTypeConfiguration<MaterialWorkshopsEntity>
{
    public void Configure(EntityTypeBuilder<MaterialWorkshopsEntity> builder)
    {
        builder.ToTable("Material Workshops").HasKey(mw => new { mw.MaterialId, mw.WorkshopId });

        builder.HasOne<MaterialEntity>(mw => mw.Material)
            .WithMany(material => material.Workshops)
            .HasForeignKey(mw => mw.MaterialId);

        builder.HasOne<WorkshopEntity>(mw => mw.Workshop)
            .WithMany(workshop => workshop.Materials)
            .HasForeignKey(mw => mw.WorkshopId);
    }
}