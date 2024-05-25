using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders").HasKey(order => order.Id);

        builder.HasOne<WorkshopEntity>(order => order.Requester)
            .WithMany(workshop => workshop.Requested)
            .HasForeignKey(order => order.RequesterId);

        builder.HasOne<WorkshopEntity>(order => order.Closer)
            .WithMany(workshop => workshop.Closed)
            .HasForeignKey(order => order.CloserId);
    }
}