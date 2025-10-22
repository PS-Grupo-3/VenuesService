using Microsoft.AspNetCore.Mvc;
using Infrastructure.Persistence; 
using Domain.Entities;          
using Microsoft.EntityFrameworkCore; 
using MediatR;
using Application.Features.Venue.Queries;
using Application.Models.Requests;
using Application.Features.Venue.Commands;

namespace VenueService.Controllers
{
    [Route("api/v1//[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IMediator _mediator;

       
        public VenueController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _mediator.Send(new GetAllVenuesQuery());
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVenueRequest request)
        {
            var result = await _mediator.Send(new UpdateVenueCommad(request));
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