using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class WorkshopConfiguration : IEntityTypeConfiguration<WorkshopEntity>
{
    public void Configure(EntityTypeBuilder<WorkshopEntity> builder)
    {
        builder.ToTable("Workshops").HasKey(workshop => workshop.Id);
    }
}