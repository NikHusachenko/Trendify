using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class SupplierConfiguration : IEntityTypeConfiguration<SupplierEntity>
{
    public void Configure(EntityTypeBuilder<SupplierEntity> builder)
    {
        builder.ToTable("Suppliers").HasKey(supplier => supplier.Id);

        builder.HasOne<CredentialsEntity>(supplier => supplier.Credentials)
            .WithOne()
            .HasForeignKey<SupplierEntity>(supplier => supplier.CredentialsId);
    }
}