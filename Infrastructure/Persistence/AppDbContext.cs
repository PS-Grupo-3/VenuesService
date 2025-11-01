using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<VenueType> VenueTypes { get; set; }

        public DbSet<Shape> Shapes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
