using Microsoft.EntityFrameworkCore;
using Weather.DAL.Models;

namespace Weather.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CurrentWeather> Weather {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrentWeather>().HasKey(w => w.Id);
            modelBuilder.Entity<CurrentWeather>().Property(w => w.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<CurrentWeather>().Property(w => w.Temp).IsRequired();
            modelBuilder.Entity<CurrentWeather>().Property(w => w.Feels_Like).IsRequired();
            modelBuilder.Entity<CurrentWeather>().Property(w => w.Sunrise).IsRequired();
            modelBuilder.Entity<CurrentWeather>().Property(w => w.Sunset).IsRequired();
        }
    }
}
