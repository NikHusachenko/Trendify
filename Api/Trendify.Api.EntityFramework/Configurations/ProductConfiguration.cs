using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products").HasKey(product => product.Id);

        builder.HasOne<WorkshopEntity>(product => product.Workshop)
            .WithMany(workshop => workshop.Products)
            .HasForeignKey(product => product.WorkshopId);

    }
}