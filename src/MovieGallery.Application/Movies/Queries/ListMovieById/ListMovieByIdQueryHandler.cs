using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Errors;

namespace MovieGallery.Application.Movies.Queries.ListMovieById;

public class ListMovieByIdQueryHandler(IMovieRepository movieRepository)
    : IRequestHandler<ListMovieByIdQuery, Result<MovieResult>>
{
    public async Task<Result<MovieResult>> Handle(
        ListMovieByIdQuery query,
        CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetById(query.Id, cancellationToken);

        return movie is null
            ? Result.Failure<MovieResult>(DomainErrors.Movie.MovieNotFound(query.Id))
            : new MovieResult(movie);
    }
}