using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageEntity>
{
    public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
    {
        builder.ToTable("Product images").HasKey(image => image.Id);

        builder.HasOne<ProductEntity>(image => image.Product)
            .WithMany(product => product.Images)
            .HasForeignKey(image => image.ProductId);
    }
}