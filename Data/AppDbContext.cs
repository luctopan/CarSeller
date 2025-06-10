using CarSeller.Data.Mappings;
using CarSeller.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSeller.Data;

public class AppDbContext : DbContext
{
    // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=CarSeller;User ID=sa;Password=1q2w3e4r@#$");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }
    
}