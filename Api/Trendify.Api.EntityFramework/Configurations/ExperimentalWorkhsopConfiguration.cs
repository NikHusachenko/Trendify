using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class ExperimentalWorkshopConfiguration : IEntityTypeConfiguration<ExperimentalWorkshopEntity>
{
    public void Configure(EntityTypeBuilder<ExperimentalWorkshopEntity> builder)
    {
        builder.ToTable("ExperimentalWorkshop").HasKey(ew => ew.Id);

        builder.Property(ew => ew.State).IsRequired(true).HasConversion<int>();
        builder.Property(ew => ew.Address).IsRequired(true).HasMaxLength(63);

    }
}