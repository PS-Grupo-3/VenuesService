using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class VenueTypeConfiguration : IEntityTypeConfiguration<VenueType>

    {
        public void Configure(EntityTypeBuilder<VenueType> builder)
        {
            builder.ToTable("VenueType");
            builder.HasKey(venuetype => venuetype.VenueTypeId);

            builder.Property(venuetype => venuetype.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new VenueType { VenueTypeId = 1, Name = "Stadium" },
                new VenueType { VenueTypeId = 2, Name = "Theater" },
                new VenueType { VenueTypeId = 3, Name = "Field" }
                );
        }
    }
}
