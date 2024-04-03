using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class OfficeConfiguration : IEntityTypeConfiguration<OfficeConfiguration>
{
    public void Configure(EntityTypeBuilder<OfficeConfiguration> builder)
    {
        builder.ToTable("Offices").HasKey(office => office.Id);

        builder.Property(office => office.FirstName).IsRequired(true).HasMaxLength(63);
    }
}