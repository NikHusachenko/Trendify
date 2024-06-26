﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trendify.Api.Database.Entities;

namespace Trendify.Api.EntityFramework.Configurations;

public sealed class SupplyConfiguration : IEntityTypeConfiguration<SupplyEntity>
{
    public void Configure(EntityTypeBuilder<SupplyEntity> builder)
    {
        builder.ToTable("Supplies").HasKey(supply => supply.Id);

        builder.HasOne<SupplierEntity>(supply => supply.Supplier)
            .WithMany(supplier => supplier.Suppliers)
            .HasForeignKey(supply => supply.SupplierId);

        builder.HasOne<WorkshopEntity>(supply => supply.Workshop)
            .WithMany(workshop => workshop.Supplies)
            .HasForeignKey(supply => supply.WorkshopId);
    }
}