using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class DeliveryMaterialConfiguration : IEntityTypeConfiguration<DeliveryMaterialEntity>
{
    public void Configure(EntityTypeBuilder<DeliveryMaterialEntity> builder)
    {
        builder.ToTable("Delivery materials").HasKey(dm => new { dm.SupplyId, dm.MaterialId });

        builder.HasOne<MaterialEntity>(dm => dm.Material)
            .WithMany(material => material.Supplies)
            .HasForeignKey(dm => dm.MaterialId);

        builder.HasOne<SupplyEntity>(dm => dm.Supply)
            .WithMany(supply => supply.Materials)
            .HasForeignKey(dm => dm.SupplyId);
    }
}