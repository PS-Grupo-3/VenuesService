using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations
{
    public class SeatConfiguration :IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seat");
            builder.HasKey(seat => seat.SeatId);

            builder.Property(seat => seat.RowNumber)
                .IsRequired();

            builder.Property(seat => seat.ColumnNumber)
                .IsRequired();

            builder.HasOne(seat => seat.ControlledSectorNavigation)
                .WithMany(controlledsectors => controlledsectors.Seats)
                .HasForeignKey(seat => seat.ControlledSector)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
