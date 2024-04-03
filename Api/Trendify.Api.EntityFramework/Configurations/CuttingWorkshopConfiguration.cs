using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class CuttingWorkshopConfiguration : IEntityTypeConfiguration<CuttingWorkshopEntity>
{
    public void Configure(EntityTypeBuilder<CuttingWorkshopEntity> builder)
    {
        builder.ToTable("CuttingWorkshop").HasKey(cut => cut.Id);

        builder.Property(cut => cut.State).IsRequired(true).HasConversion<int>();
        builder.Property(cut => cut.Address).IsRequired(true).HasMaxLength(63);


    }
}