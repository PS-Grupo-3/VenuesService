using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Queries
{
    public record GetSectorByIdQuery(Guid SectorId) : IRequest<SectorDetailResponse>;
}