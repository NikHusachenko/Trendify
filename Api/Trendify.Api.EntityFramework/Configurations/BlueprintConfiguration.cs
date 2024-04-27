using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class BlueprintConfiguration : IEntityTypeConfiguration<BlueprintEntity>
{
    public void Configure(EntityTypeBuilder<BlueprintEntity> builder)
    {
        builder.ToTable("Blueprints").HasKey(blueprint => blueprint.Id);
    }
}