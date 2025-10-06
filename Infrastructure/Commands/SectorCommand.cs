using Application.Interfaces.Command;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class SectorCommand : ISectorCommand
    {
        private readonly AppDbContext _context;

        public SectorCommand(AppDbContext context)
        {
            _context = context;
        }
    }
}
