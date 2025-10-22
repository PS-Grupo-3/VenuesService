using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Queries
{
    public record GetAllSectorsQuery() : IRequest<List<SectorResponse>>;
}