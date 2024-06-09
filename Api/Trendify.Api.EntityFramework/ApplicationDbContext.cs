using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Configurations;

namespace Trendify.Api.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<DeliveryMaterialEntity> DeliveryMaterials { get; set; }
    public DbSet<MaterialEntity> Materials { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductImageEntity> ProductImages { get; set; }
    public DbSet<ProductWorkshopsEntity> ProductWorkshops { get; set; }
    public DbSet<SupplierEntity> Suppliers { get; set; }
    public DbSet<SupplyEntity> Supplies { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WorkshopEntity> Workshops { get; set; }
    public DbSet<CredentialsEntity> Credentials { get; set; }
    public DbSet<AuthenticationTokenEntity> AuthenticationTokens { get; set; }
    public DbSet<MaterialOrdersEntity> MaterialOrders { get; set; }
    public DbSet<ProductMaterialsEntity> ProductMaterials { get; set; }
    public DbSet<UserProductsEntity> UserProducts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DeliveryMaterialConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
        modelBuilder.ApplyConfiguration(new ProductWorkshopsConfiguration());
        modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        modelBuilder.ApplyConfiguration(new SupplyConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkshopConfiguration());
        modelBuilder.ApplyConfiguration(new CredentialsConfiguration());
        modelBuilder.ApplyConfiguration(new AuthenticationTokenConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialOrdersConfiguration());
        modelBuilder.ApplyConfiguration(new ProductMaterialConfiguration());
        modelBuilder.ApplyConfiguration(new UserProductsConfiguration());
    }
}