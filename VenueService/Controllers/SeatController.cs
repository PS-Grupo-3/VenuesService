using Application.Features.Seat.Commands;
using Application.Features.Seat.Queries;
using Application.Features.Venue.Commands;
using Application.Features.Venue.Queries;
using Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VenueService.Controllers
{
    [Route("api/v1//[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;


        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mediator.Send(new GetAllSeatsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSeatRequest request)
        {
            var result = await _mediator.Send(new UpdateSeatCommand(request));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteSeatRequest { SeatId = id };
            var result = await _mediator.Send(new DeleteSeatCommand(request));
            return Ok(result);

        }
    }
}
