using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class MaterialConfiguration : IEntityTypeConfiguration<MaterialEntity>
{
    public void Configure(EntityTypeBuilder<MaterialEntity> builder)
    {
        builder.ToTable("Materials").HasKey(material => material.Id);

        builder.HasOne<OrderEntity>(material => material.Order)
            .WithMany(order => order.Materials)
            .HasForeignKey(material => material.OrderId);
    }
}