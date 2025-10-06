using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<UncontrolledSector> UncontrolledSectors { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<ControlledSector> ControlledSectors { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<VenueType> VenueTypes { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // ---------------------- Sector inheritance (TPH) ----------------------
            modelBuilder.Entity<Sector>(b =>
            {
                b.ToTable("Sectors");
                b.HasDiscriminator<string>("SectorType")
                .HasValue<ControlledSector>("Controlled")
                .HasValue<UncontrolledSector>("Uncontrolled");


                b.Property("SectorType").HasMaxLength(50);
            });


            // ---------------------- Seat -> ControlledSector relationship ----------------------
            modelBuilder.Entity<Seat>(b =>
            {
                b.ToTable("Seats");
                b.HasOne(s => s.ControlledSector)
                .WithMany(cs => cs.Seats)
                .HasForeignKey(s => s.ControlledSectorId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


                // Composite unique index to avoid duplicates en fila/columna dentro de un sector
                b.HasIndex(s => new { s.ControlledSectorId, s.RowNumber, s.ColumnNumber }).IsUnique();
            });


            // ---------------------- Venue relationships ----------------------
            modelBuilder.Entity<Venue>(b =>
            {
                b.ToTable("Venues");
                b.HasMany(v => v.Sectors)
                .WithOne(s => s.Venue)
                .HasForeignKey(s => s.VenueId)
                .OnDelete(DeleteBehavior.Cascade);


                b.HasIndex(v => v.Location);
                b.Property(v => v.Name).IsRequired().HasMaxLength(200);
            });


            modelBuilder.Entity<VenueType>(b =>
            {
                b.ToTable("VenueTypes");
                b.HasMany(vt => vt.Venues)
                .WithOne(v => v.VenueType)
                .HasForeignKey(v => v.VenueTypeId)
                .OnDelete(DeleteBehavior.Restrict);


                b.Property(vt => vt.Name).IsRequired().HasMaxLength(100);
            });


            // ---------------------- UncontrolledSector ----------------------
            modelBuilder.Entity<UncontrolledSector>(b =>
            {
                b.Property(u => u.Capacity).HasDefaultValue(0);
            });


            // ---------------------- Additional constraints / defaults ----------------------
            modelBuilder.Entity<Seat>().Property(s => s.RowNumber).IsRequired();
            modelBuilder.Entity<Seat>().Property(s => s.ColumnNumber).IsRequired();


            // Si quisieras usar TPT en lugar de TPH, aquí podrías configurarlo explícitamente.
        }

    }
}