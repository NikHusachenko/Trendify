using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Categories").HasKey(category => category.Id);

        builder.Property(category => category.Name).IsRequired(true).HasMaxLength(63);
        builder.Property(category => category.Description).IsRequired(false).HasMaxLength(511);
    }
}