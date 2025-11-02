using MediatR;
using Application.Models.Responses;

namespace Application.Features.SeatStrategy;

public record GenerateSeatsForSectorCommand(Guid SectorId) : IRequest<GenerateSeatsResultResponse>;