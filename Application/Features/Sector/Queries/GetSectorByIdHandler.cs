using Application.Features.Sector.Queries;
using Application.Features.Seat.Queries;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Queries
{
    public class GetSectorByIdHandler : IRequestHandler<GetSectorByIdQuery, SectorDetailResponse>
    {
        public Task<SectorDetailResponse> Handle(GetSectorByIdQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implementar 
            throw new NotImplementedException();
        }
    }
}