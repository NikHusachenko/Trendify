using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.EntityFramework.Configurations;

namespace Trendify.Api.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CuttingsEntity> Cuttings { get; set; }
    public DbSet<CuttingWorkshopEntity> CuttingWorkshops { get; set; }
    public DbSet<ExperimentalWorkshopEntity> ExperimentalWorkshops { get; set; }
    public DbSet<OfficeEntity> Offices { get; set; }
    public DbSet<PositionEntity> Positions { get; set; }
    public DbSet<PreparatoryWorkshopEntity> preparatoryWorkshops { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<RollEntity> Rolls { get; set; }
    public DbSet<SewingWorkshopEntity> SewingWorkshops { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WarehouseEntity> Warehouses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CuttingConfiguration());
        modelBuilder.ApplyConfiguration(new CuttingWorkshopConfiguration());
        modelBuilder.ApplyConfiguration(new ExperimentalWorkshopConfiguration());
        modelBuilder.ApplyConfiguration(new OfficeConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new PreparatoryWorkshopConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new RollCofiguration());
        modelBuilder.ApplyConfiguration(new SewingWorkshopConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
    }
}