using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class ProductWorkshopsConfiguration : IEntityTypeConfiguration<ProductWorkshopsEntity>
{
    public void Configure(EntityTypeBuilder<ProductWorkshopsEntity> builder)
    {
        builder.ToTable("Product Workshops").HasKey(pw => new { pw.ProductId, pw.WorkshopId });

        builder.HasOne<ProductEntity>(pw => pw.Product)
            .WithMany(product => product.Workshops)
            .HasForeignKey(pw => pw.ProductId);

        builder.HasOne<WorkshopEntity>(pw => pw.Workshop)
            .WithMany(workshop => workshop.Products)
            .HasForeignKey(pw => pw.WorkshopId);
    }
}