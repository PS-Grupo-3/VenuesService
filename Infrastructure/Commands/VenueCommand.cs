using Application.Interfaces.Command;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class VenueCommand : IVenueCommand
    {
        private readonly AppDbContext _context;

        public VenueCommand(AppDbContext context)
        {
            _context = context;
        }
    }
}
