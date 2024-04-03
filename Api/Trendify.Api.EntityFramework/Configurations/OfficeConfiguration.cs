using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class OfficeConfiguration : IEntityTypeConfiguration<OfficeEntity>
{
    public void Configure(EntityTypeBuilder<OfficeEntity> builder)
    {
        builder.ToTable("Offices").HasKey(office => office.Id);

        builder.Property(office => office.OfficeType).IsRequired(true).HasConversion<int>();
    }
}