using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class PreparatoryWorkshopConfiguration : IEntityTypeConfiguration<PreparatoryWorkshopEntity>
{
    public void Configure(EntityTypeBuilder<PreparatoryWorkshopEntity> builder)
    {
        builder.ToTable("PreparatoryWorkshop").HasKey(pw => pw.Id);

        builder.Property(pw => pw.State).IsRequired(true).HasConversion<int>();
        builder.Property(pw => pw.Address).IsRequired(true).HasMaxLength(63);

    }
}