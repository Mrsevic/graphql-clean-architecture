using ConferencePlanner.Application.Tracks.Queries.GetTrackByName;
using ConferencePlanner.Application.Tracks.Queries.GetTracks;
using ConferencePlanner.Application.Tracks.Queries.GetTracksByNames;
using ConferencePlanner.Domain.Entities;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MediatR;

namespace ConferencePlanner.GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class TrackQueries
    {
        [UsePaging]
        public async Task<IQueryable<Track>> GetTracks(
            [Service] IMediator mediator,
            CancellationToken cancellationToken) 
            => await mediator.Send(new GetTracksQuery(), cancellationToken);

        public async Task<Track?> GetTrackByNameAsync(
            GetTrackByNameQuery input,
            [Service] IMediator mediator,
            CancellationToken cancellationToken) 
            => await mediator.Send(input, cancellationToken);

        public async Task<IEnumerable<Track>> GetTrackByNamesAsync(
            GetTracksByNamesQuery input,
            [Service] IMediator mediator,
            CancellationToken cancellationToken) 
            => await mediator.Send(input, cancellationToken);

        public Task<Track> GetTrackByIdAsync(
            [ID(nameof(Track))] int id,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken) 
            => trackById.LoadAsync(id, cancellationToken);

        public async Task<IEnumerable<Track>> GetSessionsByIdAsync(
            [ID(nameof(Track))] int[] ids,
            TrackByIdDataLoader trackById,
            CancellationToken cancellationToken) 
            => await trackById.LoadAsync(ids, cancellationToken);
    }
}