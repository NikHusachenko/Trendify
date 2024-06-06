using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class ProductMaterialConfiguration : IEntityTypeConfiguration<ProductMaterialsEntity>
{
    public void Configure(EntityTypeBuilder<ProductMaterialsEntity> builder)
    {
        builder.ToTable("Product Materials").HasKey(pm => new { pm.ProductId, pm.MaterialId });

        builder.HasOne<ProductEntity>(pm => pm.Product)
            .WithMany(product => product.Materials)
            .HasForeignKey(pm => pm.ProductId);

        builder.HasOne<MaterialEntity>(pm => pm.Material)
            .WithMany(material => material.Products)
            .HasForeignKey(pm => pm.MaterialId);
    }
}