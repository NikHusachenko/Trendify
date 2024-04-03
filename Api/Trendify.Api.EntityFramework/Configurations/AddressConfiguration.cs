using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.ToTable("Adresses").HasKey(address => address.Id);

        builder.Property(address => address.Country).IsRequired(true).HasMaxLength(63);
        builder.Property(address => address.State).IsRequired(true).HasMaxLength(63);
        builder.Property(address => address.City).IsRequired(false).HasMaxLength(63);
        builder.Property(address => address.Street).IsRequired(true).HasMaxLength(127);
        builder.Property(address => address.Building).IsRequired(true).HasMaxLength(31);
        builder.Property(address => address.Flat).IsRequired(false).HasMaxLength(63);

        builder.HasOne<OfficeEntity>(address => address.Office)
            .WithOne(office => office.Address)
            .HasForeignKey<AddressEntity>(address => address.OfficeId);

         builder.HasOne<PreparatoryWorkshopEntity>(address => address.PreparatoryWorkshop)
            .WithOne(pr => pr.Address)
            .HasForeignKey<AddressEntity>(address => address.PreparatoryWorkshopId);

         builder.HasOne<CuttingWorkshopEntity>(address => address.CuttingWorkshop)
            .WithOne(cw => cw.Address)
            .HasForeignKey<AddressEntity>(address => address.CuttingWorkshopId);

         builder.HasOne<ExperimentalWorkshopEntity>(address => address.ExperimentalWorkshop)
            .WithOne(exp => exp.Address)
            .HasForeignKey<AddressEntity>(address => address.ExperimentalWorkshopId);

         builder.HasOne<SewingWorkshopEntity>(address => address.SewingWorkshop)
            .WithOne(office => office.Address)
            .HasForeignKey<AddressEntity>(address => address.SewingWorkshopId);

         builder.HasOne<WarehouseEntity>(address => address.Warehouse)
            .WithOne(wh => wh.Address)
            .HasForeignKey<AddressEntity>(address => address.WarehouseId);
    }
}