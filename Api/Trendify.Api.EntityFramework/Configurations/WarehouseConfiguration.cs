using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class WarehouseConfiguration : IEntityTypeConfiguration<WarehouseEntity>
{
    public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
    {
        builder.ToTable("Warehouse").HasKey(wh => wh.Id);

        builder.Property(wh => wh.State).IsRequired(true).HasConversion<int>();
        builder.Property(wh => wh.Address).IsRequired(true).HasMaxLength(63);
        

    }
}