using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.ToTable("Comments").HasKey(comment => comment.Id);

        builder.Property(comment => comment.Content).IsRequired(true).HasMaxLength(255);

        builder.HasOne<UserEntity>(comment => comment.User)
            .WithMany(user => user.Comments)
            .HasForeignKey(comment => comment.UserId);

        builder.HasOne<ProductEntity>(comment => comment.Product)
            .WithMany(product => product.Comments)
            .HasForeignKey(comment => comment.ProductId);
    }
}