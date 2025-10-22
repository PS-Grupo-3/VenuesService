using Application.Models.Requests;
using Application.Models.Responses; 
using MediatR;

namespace Application.Features.Venue.Commands
{
    public record DeleteVenueCommand(DeleteVenueRequest request) : IRequest<GenericResponse>;
}