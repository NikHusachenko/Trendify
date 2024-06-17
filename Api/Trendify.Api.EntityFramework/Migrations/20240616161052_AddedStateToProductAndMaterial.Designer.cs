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
    [Migration("20240616161052_AddedStateToProductAndMaterial")]
    partial class AddedStateToProductAndMaterial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trendify.Api.Database.Entities.AuthenticationTokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CredentialsId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CredentialsId");

                    b.ToTable("Authentication tokens", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.CredentialsEntity", b =>
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

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Credentials", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.DeliveryMaterialEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Delivered")
                        .HasColumnType("integer");

                    b.Property<int>("Left")
                        .HasColumnType("integer");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SupplyId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("SupplyId");

                    b.ToTable("Delivery materials", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ColorRgb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Materials", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialOrdersEntity", b =>
                {
                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MaterialId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("Material Orders", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CloserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CloserId");

                    b.HasIndex("RequesterId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

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

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductMaterialsEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("MaterialCount")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProductId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Product Materials", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductWorkshopsEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

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

                    b.Property<Guid>("WorkshopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Supplies", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CredentialsId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
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

                    b.HasIndex("CredentialsId")
                        .IsUnique();

                    b.HasIndex("WorkshopId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserProductsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("User Products", (string)null);
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

            modelBuilder.Entity("Trendify.Api.Database.Entities.AuthenticationTokenEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.CredentialsEntity", "Credentials")
                        .WithMany("AuthenticationTokens")
                        .HasForeignKey("CredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credentials");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.DeliveryMaterialEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.MaterialEntity", "Material")
                        .WithMany("Supplies")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.SupplyEntity", "Supply")
                        .WithMany("Materials")
                        .HasForeignKey("SupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Supply");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialOrdersEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.MaterialEntity", "Material")
                        .WithMany("Orders")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.OrderEntity", "Order")
                        .WithMany("Materials")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.OrderEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Closer")
                        .WithMany("Closed")
                        .HasForeignKey("CloserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Requester")
                        .WithMany("Requested")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Closer");

                    b.Navigation("Requester");
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

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductMaterialsEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.MaterialEntity", "Material")
                        .WithMany("Products")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.ProductEntity", "Product")
                        .WithMany("Materials")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

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

                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Workshop")
                        .WithMany("Supplies")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.CredentialsEntity", "Credentials")
                        .WithOne("User")
                        .HasForeignKey("Trendify.Api.Database.Entities.UserEntity", "CredentialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.WorkshopEntity", "Workshop")
                        .WithMany("Users")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credentials");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserProductsEntity", b =>
                {
                    b.HasOne("Trendify.Api.Database.Entities.ProductEntity", "Product")
                        .WithMany("Producers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Trendify.Api.Database.Entities.UserEntity", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.CredentialsEntity", b =>
                {
                    b.Navigation("AuthenticationTokens");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.MaterialEntity", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.OrderEntity", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.ProductEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Materials");

                    b.Navigation("Producers");

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

            modelBuilder.Entity("Trendify.Api.Database.Entities.UserEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Trendify.Api.Database.Entities.WorkshopEntity", b =>
                {
                    b.Navigation("Closed");

                    b.Navigation("Products");

                    b.Navigation("Requested");

                    b.Navigation("Supplies");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
