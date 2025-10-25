using Application.Features.Sector.Commands;
using Application.Features.Sector.Queries;
using Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VenueService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly IMediator _mediator;


        public SectorController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("/api/v1/venues/{venueId:guid}/sectors")]
        public async Task<IActionResult> GetSectorsForVenue(Guid venueId)
        {
            // 1. Creas un Query que ACEPTA el venueId
            var query = new GetSectorsForVenueQuery(venueId);

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSectorByIdQuery(id));
            return Ok(result);

        }

        [HttpPost("{venueId:guid}/sectors")]
        public async Task<IActionResult> CreateSector(Guid venueId, [FromBody] CreateSectorRequest request)
        { 
            var command = new CreateSectorCommand(venueId, request);

            var response = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(SectorController.GetById), 
                "Sector",
                new { id = response.SectorId },
                response
            );
        }

        [HttpPut("{id:guid}")] 
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSectorRequest request) 
        {
            var command = new UpdateSectorCommand(id, request);

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
            var request = new DeleteSectorRequest { SectorId = id };
            var result = await _mediator.Send(new DeleteSectorCommand(request));
            return Ok(result);

        }
    }
}
