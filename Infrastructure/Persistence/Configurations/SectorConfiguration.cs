using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class SectorConfiguration : IEntityTypeConfiguration<Sector>
    {
        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            builder.ToTable("Sector");
            builder.HasKey(sector => sector.SectorId);

            builder.Property(sector => sector.Name)
                .IsRequired()
                .HasMaxLength(50);


            builder.HasOne(sector => sector.VenueNavigation)
                .WithMany(venue => venue.Sectors)
                .HasForeignKey(sector => sector.Venue)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
