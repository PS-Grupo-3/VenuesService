using Application.Features.VenueType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VenueService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VenueTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenueTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllVenueTypesQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetVenueTypeByIdQuery(id));
            return Ok(result);
        }
    }
}
