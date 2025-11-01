using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ShapeConfiguration : IEntityTypeConfiguration<Shape>
    {
        public void Configure(EntityTypeBuilder<Shape> builder)
        {
            builder.ToTable("Shape");

            builder.HasKey(s => s.ShapeId);

            builder.Property(s => s.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(s => s.Colour)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasDefaultValue("#FFFFFF");

            builder.HasOne(shape => shape.Sector)
                   .WithOne(sector => sector.Shape)
                   .HasForeignKey<Shape>(shape => shape.SectorId);
        }
    }
}