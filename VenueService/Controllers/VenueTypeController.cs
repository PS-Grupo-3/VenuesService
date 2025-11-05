using Application.Features.VenueType.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace VenueService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class VenueTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenueTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar tipos de venue",
            Description = "Obtiene la lista completa de tipos de venue disponibles en el sistema."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetAllVenueTypesQuery(), ct);
            return Ok(result);
        }
        
        [HttpGet("{id:int}")]
        [SwaggerOperation(
            Summary = "Obtener tipo de venue por Id",
            Description = "Devuelve la información del tipo de venue correspondiente al identificador especificado."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetVenueTypeByIdQuery(id), ct);

            if (result is null)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el tipo de venue con Id {id}."
                });

            return Ok(result);
        }
    }
}
