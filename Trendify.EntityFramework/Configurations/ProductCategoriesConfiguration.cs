using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class ProductCategoriesConfiguration : IEntityTypeConfiguration<ProductCategoriesEntity>
{
    public void Configure(EntityTypeBuilder<ProductCategoriesEntity> builder)
    {
        builder.ToTable("Product Categories").HasKey(pc => new { pc.ProductId, pc.CategoryId });

        builder.HasOne<ProductEntity>(pc => pc.Product)
            .WithMany(product => product.Categories)
            .HasForeignKey(pc => pc.CategoryId);

        builder.HasOne<CategoryEntity>(pc => pc.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(cp => cp.CategoryId);
    }
}