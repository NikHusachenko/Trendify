using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products").HasKey(pr => pr.Id);

        builder.Property(pr => pr.Name).IsRequired(true).HasMaxLength(63);
        builder.Property(pr => pr.Description).IsRequired(true).HasMaxLength(250);
        builder.Property(pr => pr.MaterialsIsNeeded).IsRequired(true).HasMaxLength(63);
        builder.Property(pr => pr.WorkNeeded).IsRequired(true).HasMaxLength(63);
        builder.Property(pr => pr.Rate).IsRequired(true);
        builder.Property(pr => pr.Count).IsRequired(true);
        builder.Property(pr => pr.Color).IsRequired(true).HasMaxLength(40);
        builder.Property(pr => pr.RAL).IsRequired(true);
        builder.Property(pr => pr.Currency).IsRequired(true).HasConversion<int>();
        builder.Property(pr => pr.Price).IsRequired(true);

        builder
        .HasOne<SewingWorkshopEntity>(pr => pr.SewingWorkshop)
        .WithMany(cw => cw.Products)
        .HasForeignKey(pr => pr.SewingWorkshopId);

                builder
        .HasOne<WarehouseEntity>(pr => pr.Warehouse)
        .WithMany(cw => cw.Products)
        .HasForeignKey(pr => pr.WarehouseId);
    }
}