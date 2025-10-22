using Microsoft.AspNetCore.Mvc;
using Infrastructure.Persistence; 
using Domain.Entities;          
using Microsoft.EntityFrameworkCore; 

namespace VenueService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly AppDbContext _context;

       
        public VenueController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
        {
       
            var venues = await _context.Venues.ToListAsync();

            return Ok(venues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venue>> GetVenueById(Guid id)
        {
            var venue = await _context.Venues.FindAsync(id);

            if (venue == null)
            {
                return NotFound(); 
            }

            return Ok(venue);
        }
    }
}