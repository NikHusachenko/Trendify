using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class MaterialBlueprintsConfiguration : IEntityTypeConfiguration<MaterialBlueprintsEntity>
{
    public void Configure(EntityTypeBuilder<MaterialBlueprintsEntity> builder)
    {
        builder.ToTable("Material Blueprints").HasKey(mb => new { mb.MaterialId, mb.BlueprintId });

        builder.HasOne<MaterialEntity>(mb => mb.Material)
            .WithMany(material => material.Blueprints)
            .HasForeignKey(mb => mb.MaterialId);

        builder.HasOne<BlueprintEntity>(mb => mb.Blueprint)
            .WithMany(blueprint => blueprint.Materials)
            .HasForeignKey(mb => mb.BlueprintId);
    }
}