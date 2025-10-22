using Application.Models.Requests;
using Application.Models.Responses;
using MediatR;

namespace Application.Features.Venue.Commands
{
    public record UpdateVenueCommad(UpdateVenueRequest Request) : IRequest<GenericResponse>;
}