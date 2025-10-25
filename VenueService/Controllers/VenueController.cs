using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Venue.Queries;
using Application.Models.Requests;
using Application.Features.Venue.Commands;

namespace VenueService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IMediator _mediator;

       
        public VenueController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]string? name, [FromQuery]string? location, [FromQuery]int? venueTypeId, [FromQuery] SortDirection? sortByCapacity)
        {

            var result = await _mediator.Send(new GetAllVenuesQuery(name,location,venueTypeId, sortByCapacity));
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVenueByIdQuery(id));
            return Ok(result);
           
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVenueRequest request)
        {
            var result = await _mediator.Send(new CreateVenueCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.VenueId }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVenueRequest request) 
        {
            var command = new UpdateVenueCommand(id, request);

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteVenueRequest { VenueId = id };
            var result = await _mediator.Send(new DeleteVenueCommand(request));
            return Ok(result);
            
        }
    }
}