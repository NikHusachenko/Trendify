using Microsoft.EntityFrameworkCore;

namespace Trendify.EntityFramework;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.Migrate();
    }
}