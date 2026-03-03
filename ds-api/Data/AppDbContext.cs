using Microsoft.EntityFrameworkCore;

namespace discounts_salling_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    // Add your DbSet properties here
    // Example: public DbSet<YourEntity> YourEntities { get; set; } = null!;
}
