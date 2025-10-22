using Application.Models.Responses;
using MediatR;

namespace Application.Features.Sector.Queries
{
    public class GetAllSectorsHandler : IRequestHandler<GetAllSectorsQuery, List<SectorResponse>>
    {
        public Task<List<SectorResponse>> Handle(GetAllSectorsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implementar
            throw new NotImplementedException();
        }
    }
}