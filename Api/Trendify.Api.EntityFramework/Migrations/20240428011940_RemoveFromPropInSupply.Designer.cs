﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trendify.Api.EntityFramework;

#nullable disable

namespace Trendify.Api.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240428011940_RemoveFromPropInSupply")]
    partial class RemoveFromPropInSupply
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trendify.Api.Database.Entities.BlueprintEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BlueprintURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Blueprints", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialBlueprintsEntity", b =>
                {
                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlueprintId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MaterialId", "BlueprintId");

                    b.HasIndex("BlueprintId");

                    b.ToTable("Material Blueprints", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AmountUnit")
                        .HasColumnType("integer");

                    b.Property<string>("ColorHex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ColorRal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ColorRgb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LocalCode")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("SupplyId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SupplyId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Materials", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Bought")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Product images", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductWorkshopsEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId", "WorkshopId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Product Workshops", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.SupplierEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.SupplyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeliveredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Supplies", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.WorkshopEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LocalAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Workshops", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialBlueprintsEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.BlueprintEntity", "Blueprint")
                        .WithMany("Materials")
                        .HasForeignKey("BlueprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.MaterialEntity", "Material")
                        .WithMany("Blueprints")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blueprint");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.OrderEntity", "Order")
                        .WithMany("Materials")
                        .HasForeignKey("OrderId");

                    b.HasOne("Trendify.Api.Database.Entities.SupplyEntity", "Supply")
                        .WithMany("Materials")
                        .HasForeignKey("SupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Workshop")
                        .WithMany("Materials")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Supply");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.OrderEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Workshop")
                        .WithMany("Orders")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductImageEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.ProductEntity", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductWorkshopsEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.ProductEntity", "Product")
                        .WithMany("Workshops")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Workshop")
                        .WithMany("Products")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.SupplyEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.SupplierEntity", "Supplier")
                        .WithMany("Suppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Workshop")
                        .WithMany("Users")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.BlueprintEntity", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialEntity", b =>
                {
                    b.Navigation("Blueprints");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.OrderEntity", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Workshops");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.SupplierEntity", b =>
                {
                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.SupplyEntity", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.WorkshopEntity", b =>
                {
                    b.Navigation("Materials");

                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
