using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class SewingWorkshopConfiguration : IEntityTypeConfiguration<SewingWorkshopEntity>
{
    public void Configure(EntityTypeBuilder<SewingWorkshopEntity> builder)
    {
        builder.ToTable("SewingWorkshop").HasKey(sw => sw.Id);

        builder.Property(sw => sw.State).IsRequired(true).HasConversion<int>();
        builder.Property(sw => sw.Address).IsRequired(true).HasMaxLength(63);
    }
}