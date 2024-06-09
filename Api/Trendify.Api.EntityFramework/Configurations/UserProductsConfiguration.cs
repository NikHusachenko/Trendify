using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class UserProductsConfiguration : IEntityTypeConfiguration<UserProductsEntity>
{
    public void Configure(EntityTypeBuilder<UserProductsEntity> builder)
    {
        builder.ToTable("User Products").HasKey(up => up.Id);

        builder.HasOne<UserEntity>(up => up.User)
            .WithMany(user => user.Products)
            .HasForeignKey(up => up.UserId);

        builder.HasOne<ProductEntity>(up => up.Product)
            .WithMany(product => product.Producers)
            .HasForeignKey(up => up.ProductId);
    }
}