using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class DeliveryMaterialConfiguration : IEntityTypeConfiguration<DeliveryMaterialEntity>
{
    public void Configure(EntityTypeBuilder<DeliveryMaterialEntity> builder)
    {
        builder.ToTable("Delivery materials").HasKey(delivery => delivery.Id);

        builder.HasOne<MaterialEntity>(delivery => delivery.Material)
            .WithMany(material => material.Supplies)
            .HasForeignKey(delivery => delivery.MaterialId);

        builder.HasOne<SupplyEntity>(delivery => delivery.Supply)
            .WithMany(supply => supply.Materials)
            .HasForeignKey(delivery => delivery.SupplyId);
    }
}