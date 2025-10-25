using Application.Features.Seat.Commands;
using Application.Features.Seat.Queries;
using Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VenueService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;


        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{sectorId:guid}/seats")]
        public async Task<IActionResult> GetSeatsForSector(Guid sectorId)
        {
            var query = new GetSeatsBySectorIdQuery(sectorId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:long}")] 
        public async Task<IActionResult> GetById(long id) 
        {
            var result = await _mediator.Send(new GetSeatByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSeatRequest request)
        {
            var result = await _mediator.Send(new CreateSeatCommand(request));
            return CreatedAtAction(nameof(GetById), new { id = result.SeatId }, result);
        }

        [HttpPut("{id:long}")] 
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSeatRequest request) 
        {
            var command = new UpdateSeatCommand(id, request);

            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id:long}")] 
        public async Task<IActionResult> Delete(long id) 
        {
            var request = new DeleteSeatRequest { SeatId = id };
            var result = await _mediator.Send(new DeleteSeatCommand(request));

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
