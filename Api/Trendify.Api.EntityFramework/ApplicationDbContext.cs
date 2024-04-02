using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;
using Trendify.EntityFramework.Configurations;

namespace Trendify.Api.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    //setTables
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserEntity> PositionsEntity { get; set; }
    //Ctom/ Migrations
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }
    //Db connection

    //Configure tables
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}