using Application.Features.Sector.Commands;
using Application.Features.Sector.Queries;
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
    public class SectorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // --------------------------------------------------------------------
        // GET /api/v1/venues/{venueId}/sectors
        // --------------------------------------------------------------------
        [HttpGet("/api/v1/venues/{venueId:guid}/sectors")]
        [SwaggerOperation(
            Summary = "Listar sectores por venue",
            Description = "Devuelve todos los sectores pertenecientes a un venue específico."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSectorsForVenue(Guid venueId, CancellationToken ct = default)
        {
            var query = new GetSectorsForVenueQuery(venueId);
            var result = await _mediator.Send(query, ct);
            return Ok(result);
        }

        // --------------------------------------------------------------------
        // GET /api/v1/sector/{id}
        // --------------------------------------------------------------------
        [HttpGet("{id:guid}")]
        [SwaggerOperation(
            Summary = "Obtener sector por Id",
            Description = "Devuelve los datos del sector correspondiente al identificador especificado."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct = default)
        {
            var result = await _mediator.Send(new GetSectorByIdQuery(id), ct);

            if (result is null)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el sector con Id {id}."
                });

            return Ok(result);
        }

        // --------------------------------------------------------------------
        // POST /api/v1/venues/{venueId}/sectors
        // --------------------------------------------------------------------
        [HttpPost("/api/v1/venues/{venueId:guid}/sectors")]
        [SwaggerOperation(
            Summary = "Crear un nuevo sector",
            Description = "Crea un nuevo sector asociado a un venue específico."
        )]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSector(Guid venueId, [FromBody] CreateSectorRequest request, CancellationToken ct = default)
        {
            if (request is null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Body requerido",
                    Detail = "Debe enviarse un cuerpo JSON con los datos del sector a crear."
                });

            var command = new CreateSectorCommand(venueId, request);
            var response = await _mediator.Send(command, ct);

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.SectorId },
                response
            );
        }

        // --------------------------------------------------------------------
        // PUT /api/v1/sector/{id}
        // --------------------------------------------------------------------
        [HttpPut("{id:guid}")]
        [SwaggerOperation(
            Summary = "Actualizar sector por Id",
            Description = "Actualiza la información de un sector existente según su identificador único."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSectorRequest request, CancellationToken ct = default)
        {
            if (request is null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Body requerido",
                    Detail = "Debe enviarse un cuerpo JSON con los datos actualizados del sector."
                });

            var command = new UpdateSectorCommand(id, request);
            var result = await _mediator.Send(command, ct);

            if (!result.Success)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el sector con Id {id} para actualizar."
                });

            return Ok(result);
        }

        // --------------------------------------------------------------------
        // DELETE /api/v1/sector/{id}
        // --------------------------------------------------------------------
        [HttpDelete("{id:guid}")]
        [SwaggerOperation(
            Summary = "Eliminar sector por Id",
            Description = "Elimina un sector de forma permanente según su identificador único."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
        {
            var request = new DeleteSectorRequest { SectorId = id };
            var result = await _mediator.Send(new DeleteSectorCommand(request), ct);

            if (!result.Success)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el sector con Id {id} para eliminar."
                });

            return Ok(result);
        }
    }
}
