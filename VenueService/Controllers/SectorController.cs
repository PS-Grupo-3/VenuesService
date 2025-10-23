using Application.Features.Sector.Commands;
using Application.Features.Sector.Queries;
using Application.Features.Venue.Commands;
using Application.Features.Venue.Queries;
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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mediator.Send(new GetAllSectorsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetSectorByIdQuery(id));
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSectorRequest request)
        {
            var result = await _mediator.Send(new CreateSectorCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.SectorId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSectorRequest request)
        {
            var result = await _mediator.Send(new UpdateSectorCommand(request));
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
