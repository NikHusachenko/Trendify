using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users").HasKey(user => user.Id);

        builder.Property(user => user.FirstName).IsRequired(true).HasMaxLength(63);
        builder.Property(user => user.LastName).IsRequired(true).HasMaxLength(63);
        builder.Property(user => user.MiddleName).IsRequired(false).HasMaxLength(63);
        builder.Property(user => user.Email).IsRequired(true).HasMaxLength(127);
        builder.Property(user => user.Phone).IsRequired(true).HasMaxLength(31);
        builder.Property(user => user.Login).IsRequired(true).HasMaxLength(63);
        builder.Property(user => user.HashedPassword).IsRequired(true);

        builder
        .HasOne<OfficeEntity>(user => user.Office)
        .WithMany(office => office.Workers)
        .HasForeignKey(user => user.OfficeId);

        builder
        .HasOne<ExperimentalWorkshopEntity>(user => user.ExperimentalWorkshop)
        .WithMany(exp => exp.Workers)
        .HasForeignKey(user => user.ExperimentalWorkshopId);

                builder
        .HasOne<PreparatoryWorkshopEntity>(user => user.PreparatoryWorkshop)
        .WithMany(exp => exp.Workers)
        .HasForeignKey(user => user.PreparatoryWorkshopId);

                builder
        .HasOne<CuttingWorkshopEntity>(user => user.CuttingWorkshop)
        .WithMany(exp => exp.Workers)
        .HasForeignKey(user => user.CuttingWorkshopId);

                builder
        .HasOne<SewingWorkshopEntity>(user => user.SewingWorkshop)
        .WithMany(exp => exp.Workers)
        .HasForeignKey(user => user.SewingWorkshopId);

                builder
        .HasOne<WarehouseEntity>(user => user.Warehouse)
        .WithMany(exp => exp.Workers)
        .HasForeignKey(user => user.WarehouseId);
    }
}