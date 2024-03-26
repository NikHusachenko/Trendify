using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class FaqConfiguration : IEntityTypeConfiguration<FaqEntity>
{
    public void Configure(EntityTypeBuilder<FaqEntity> builder)
    {
        builder.ToTable("Faq").HasKey(f => f.Id);
    }
}