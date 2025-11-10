using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seat");
            builder.HasKey(seat => seat.SeatId);

            builder.Property(seat => seat.RowNumber)
                   .IsRequired();

            builder.Property(seat => seat.ColumnNumber)
                   .IsRequired();

            builder.Property(seat => seat.PosX)
                   .IsRequired();

            builder.Property(seat => seat.PosY)
                   .IsRequired();

            builder.HasOne(seat => seat.SectorNavigation)
                   .WithMany(sectors => sectors.Seats)
                   .HasForeignKey(seat => seat.SectorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}