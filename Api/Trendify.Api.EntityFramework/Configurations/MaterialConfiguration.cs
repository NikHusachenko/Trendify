using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class MaterialConfiguration : IEntityTypeConfiguration<MaterialEntity>
{
    public void Configure(EntityTypeBuilder<MaterialEntity> builder)
    {
        builder.ToTable("Materials").HasKey(material => material.Id);
    
        builder.HasOne<SupplyEntity>(material => material.Supply)
            .WithMany(supply => supply.Materials)
            .HasForeignKey(material => material.SupplyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<WorkshopEntity>(material => material.Workshop)
            .WithMany(workshop => workshop.Materials)
            .HasForeignKey(material => material.WorkshopId);
    }
}