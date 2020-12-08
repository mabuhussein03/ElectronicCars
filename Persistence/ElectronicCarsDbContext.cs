using Microsoft.EntityFrameworkCore;
using ElectronicCars.Core.Models;
namespace ElectronicCars.Persistence
{
    public class ElectronicCarsDbContext : DbContext
    {
        public DbSet<SalesLocation> SalesLocations { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public ElectronicCarsDbContext(DbContextOptions<ElectronicCarsDbContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=CustomerDB.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesLocation>().ToTable("SalesLocations");
            modelBuilder.Entity<Sale>().ToTable("Sales");
        }
    }
}