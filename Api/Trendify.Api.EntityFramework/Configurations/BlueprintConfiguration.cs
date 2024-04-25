using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class BlueprintConfiguration : IEntityTypeConfiguration<BlueprintEntity>
{
    public void Configure(EntityTypeBuilder<BlueprintEntity> builder)
    {
        builder.ToTable("Blueprints").HasKey(bp => bp.Id);

        builder.HasOne<ProductEntity>(product => product.Product)
        .WithOne(pr => pr.Blueprint)
        .HasForeignKey<BlueprintEntity>(product => product.ProductId);


    }
}