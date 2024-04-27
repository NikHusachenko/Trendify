using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders").HasKey(order => order.Id);

        builder.HasOne<WorkshopEntity>(order => order.Workshop)
            .WithMany(workshop => workshop.Orders)
            .HasForeignKey(order => order.WorkshopId);
    }
}