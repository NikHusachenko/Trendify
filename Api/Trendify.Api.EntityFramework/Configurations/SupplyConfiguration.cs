using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

internal sealed class SupplyConfiguration : IEntityTypeConfiguration<SupplyEntity>
{
    public void Configure(EntityTypeBuilder<SupplyEntity> builder)
    {
        builder.ToTable("Supplies").HasKey(supply => supply.Id);
    }
}