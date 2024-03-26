using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class CartProductsConfiguration : IEntityTypeConfiguration<CartProductsEntity>
{
    public void Configure(EntityTypeBuilder<CartProductsEntity> builder)
    {
        builder.ToTable("Cart Products").HasKey(cp => new { cp.CartId, cp.ProductId });

        builder.HasOne<CartEntity>(cp => cp.Cart)
            .WithMany(cart => cart.Products)
            .HasForeignKey(cp => cp.CartId);

        builder.HasOne<ProductEntity>(cp => cp.Product)
            .WithMany(product => product.Carts)
            .HasForeignKey(cp => cp.ProductId);
    }
}