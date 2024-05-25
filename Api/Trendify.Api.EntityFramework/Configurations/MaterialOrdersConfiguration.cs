using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class MaterialOrdersConfiguration : IEntityTypeConfiguration<MaterialOrdersEntity>
{
    public void Configure(EntityTypeBuilder<MaterialOrdersEntity> builder)
    {
        builder.ToTable("Material Orders").HasKey(mo => new { mo.MaterialId, mo.OrderId });

        builder.HasOne<MaterialEntity>(mo => mo.Material)
            .WithMany(material => material.Orders)
            .HasForeignKey(mo => mo.MaterialId);

        builder.HasOne<OrderEntity>(mo => mo.Order)
            .WithMany(order => order.Materials)
            .HasForeignKey(mo => mo.OrderId);
    }
}