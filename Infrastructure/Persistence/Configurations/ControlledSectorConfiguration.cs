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
    public class ControlledSectorConfiguration : IEntityTypeConfiguration<ControlledSector>

    {
        public void Configure(EntityTypeBuilder<ControlledSector> builder)
        {
            builder.Property(controlledsector => controlledsector.SeatCount)
                .IsRequired();
        }

    }
}
