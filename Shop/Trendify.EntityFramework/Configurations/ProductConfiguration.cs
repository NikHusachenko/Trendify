using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products").HasKey(product => product.Id);

        builder.Property(product => product.Name).IsRequired(true).HasMaxLength(63);
        builder.Property(product => product.Description).IsRequired(true).HasMaxLength(1027);
        builder.Property(product => product.ShortDescription).IsRequired(true).HasMaxLength(63);
    }
}