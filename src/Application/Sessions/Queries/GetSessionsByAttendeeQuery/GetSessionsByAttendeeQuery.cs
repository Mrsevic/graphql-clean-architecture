using ConferencePlanner.Domain.Entities;
using HotChocolate.Types.Relay;
using MediatR;

namespace ConferencePlanner.Application.Sessions.Queries.GetSessionsByAttendeeQuery
{ 
    public record GetSessionsByAttendeeQuery([property:ID(nameof(Attendee))] int Id) 
        : IRequest<IEnumerable<Session>>;
}

