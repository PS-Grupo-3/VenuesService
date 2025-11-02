using Application.Features.SeatStrategy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VenueService.Controllers;

[ApiController]
[Route("api/v1/strategy")]
public class SeatStrategyController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeatStrategyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("generate/{sectorId:guid}")]
    public async Task<IActionResult> GenerateSeats(Guid sectorId)
    {
        var result = await _mediator.Send(new GenerateSeatsForSectorCommand(sectorId));

        return Ok(new
        {
            result.SectorId,
            result.SectorName,
            result.ShapeType,
            result.SeatsGenerated,
            result.GeneratedAt,
            Message = "Strategy ejecutado correctamente"
        });
    }
}