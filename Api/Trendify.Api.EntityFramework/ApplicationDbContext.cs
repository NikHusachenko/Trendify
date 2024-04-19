using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.Api.EntityFramework.Configurations;

namespace Trendify.Api.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<MaterialEntity> Materials { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductEntity> ProductImages { get; set; }
    public DbSet<SupplyEntity> Supplies { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WorkshopEntity> Workshops { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
        modelBuilder.ApplyConfiguration(new SupplyConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WorkshopConfiguration());
        modelBuilder.ApplyConfiguration(new BlueprintConfiguration());
    }
}