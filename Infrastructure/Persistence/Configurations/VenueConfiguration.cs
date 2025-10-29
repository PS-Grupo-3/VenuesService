using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable("Venue");
            builder.HasKey(venue => venue.VenueId);

            builder.Property(venue => venue.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(venue => venue.Name)
                .IsUnique();

            builder.Property(venue => venue.TotalCapacity)
                .IsRequired();

            builder.Property(venue => venue.Address)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(venue => venue.MapUrl)
                .IsRequired();

            builder.HasOne(venue => venue.VenueTypeNavigation)
                .WithMany(venuetype => venuetype.Venues)
                .HasForeignKey(venue => venue.VenueType)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
