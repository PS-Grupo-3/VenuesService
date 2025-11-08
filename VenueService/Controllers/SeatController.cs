using Application.Features.Seat.Commands;
using Application.Features.Seat.Queries;
using Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace VenueService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }        

        [HttpGet("{id:long}")]
        [SwaggerOperation(
            Summary = "Obtener asiento por Id",
            Description = "Devuelve un asiento según su identificador único."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(long id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetSeatByIdQuery(id), ct);

            if (result is null)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"El asiento con Id {id} no existe."
                });

            return Ok(result);
        }    
        
        [HttpPut("{id:long}")]
        [SwaggerOperation(
            Summary = "Actualizar asiento por Id",
            Description = "Actualiza los datos de un asiento existente según su identificador."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSeatRequest request, CancellationToken ct)
        {
            if (request is null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Body requerido",
                    Detail = "Debe enviarse un cuerpo JSON con los datos actualizados del asiento."
                });

            var result = await _mediator.Send(new UpdateSeatCommand(id, request), ct);

            if (!result.Success)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el asiento con Id {id} para actualizar."
                });

            return Ok(result);
        }
        
        [HttpDelete("{id:long}")]
        [SwaggerOperation(
            Summary = "Eliminar asiento por Id",
            Description = "Elimina un asiento de forma permanente por su identificador único."
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id, CancellationToken ct)
        {
            var request = new DeleteSeatRequest { SeatId = id };
            var result = await _mediator.Send(new DeleteSeatCommand(request), ct);

            if (!result.Success)
                return NotFound(new ProblemDetails
                {
                    Title = "No encontrado",
                    Detail = $"No se encontró el asiento con Id {id} para eliminar."
                });

            return Ok(result);
        }
    }
}
