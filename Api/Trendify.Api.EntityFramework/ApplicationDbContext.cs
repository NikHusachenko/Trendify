using Microsoft.EntityFrameworkCore;
using Trendify.Api.Database.Entities;

namespace Trendify.EntityFramework;

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