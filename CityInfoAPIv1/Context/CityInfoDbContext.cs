using CityInfoAPIv1.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPIv1.Context
{
    public class CityInfoDbContext : DbContext
    {
        public CityInfoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(p => p.PointsOfInterest)
                .WithOne();

            modelBuilder.Entity<PointOfInterest>()
                .HasOne(c => c.City)
                .WithMany(p =>p.PointsOfInterest)
                .HasForeignKey(ci => ci.CityId);
        }

    }
}
