using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class GalleryImageConfiguration : IEntityTypeConfiguration<GalleryImageEntity>
{
    public void Configure(EntityTypeBuilder<GalleryImageEntity> builder)
    {
        builder.ToTable("Gallery images").HasKey(image => image.Id);
    }
}