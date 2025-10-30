using Application.Features.Venue.Commands;
using Application.Features.Venue.Queries;
using Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace VenueService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class VenueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VenueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // --------------------------------------------------------------------
        // GET /api/v1/venue?name=...&location=...&venueTypeId=...&sortByCapacity=...
        // --------------------------------------------------------------------
        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar venues",
            Description = "Obtiene una lista de todos los venues filtrando opcionalmente por nombre, ubicación, tipo o capacidad."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? name,
            [FromQuery] string? address,
            [FromQuery] int? venueTypeId,
            [FromQuery] SortDirection? sortByCapacity,
            CancellationToken ct = default)
        {
            var result = await _mediator.Send(
                new GetAllVenuesQuery(name, address, venueTypeId, sortByCapacity),
                ct
            );

            return Ok(result);
        }

        // --------------------------------------------------------------------
        // GET /api/v1/venue/{id}
        // --------------------------------------------------------------------
        [HttpGet("{id:guid}")]
        [SwaggerOperation(
            Summary = "Obtener venue por Id",
            Description = "Devuelve los detalles del venue correspondiente al identificador especificado."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetVenueByIdQuery(id), ct);

            if (result is null)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el venue con Id {id}."
                });

            return Ok(result);
        }

        // --------------------------------------------------------------------
        // POST /api/v1/venue
        // --------------------------------------------------------------------
        [HttpPost]
        [SwaggerOperation(
            Summary = "Crear un nuevo venue",
            Description = "Crea un nuevo venue en el sistema y devuelve el recurso creado."
        )]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateVenueRequest request, CancellationToken ct = default)
        {
            if (request is null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Body requerido",
                    Detail = "Debe enviarse un cuerpo JSON con los datos del venue a crear."
                });

            var result = await _mediator.Send(new CreateVenueCommand(request), ct);

            return CreatedAtAction(nameof(GetById), new { id = result.VenueId }, result);
        }

        // --------------------------------------------------------------------
        // PUT /api/v1/venue/{id}
        // --------------------------------------------------------------------
        [HttpPut("{id:guid}")]
        [SwaggerOperation(
            Summary = "Actualizar venue por Id",
            Description = "Actualiza los datos de un venue existente según su identificador único."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVenueRequest request, CancellationToken ct = default)
        {
            if (request is null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Body requerido",
                    Detail = "Debe enviarse un cuerpo JSON con los datos actualizados del venue."
                });

            var command = new UpdateVenueCommand(id, request);
            var result = await _mediator.Send(command, ct);

            if (!result.Success)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el venue con Id {id} para actualizar."
                });

            return Ok(result);
        }

        // --------------------------------------------------------------------
        // DELETE /api/v1/venue/{id}
        // --------------------------------------------------------------------
        [HttpDelete("{id:guid}")]
        [SwaggerOperation(
            Summary = "Eliminar venue por Id",
            Description = "Elimina un venue del sistema según su identificador único."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
        {
            var request = new DeleteVenueRequest { VenueId = id };
            var result = await _mediator.Send(new DeleteVenueCommand(request), ct);

            if (!result.Success)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el venue con Id {id} para eliminar."
                });

            return Ok(result);
        }
    }
}
