using Microsoft.EntityFrameworkCore;
using Trendify.Database.Entities;
using Trendify.EntityFramework.Configurations;

namespace Trendify.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
    }
}