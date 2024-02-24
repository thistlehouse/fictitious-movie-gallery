using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMovieById;

public class ListMovieByIdQueryHandler(IMovieRepository movieRepository)
    : IRequestHandler<ListMovieByIdQuery, MovieResult>
{
    public async Task<MovieResult> Handle(
        ListMovieByIdQuery query,
        CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetById(query.Id, cancellationToken);

        return movie is null
            ? throw new Exception(
                "implement result pattern: ListMovieByIdQueryHandler")
            : new(movie);
    }
}