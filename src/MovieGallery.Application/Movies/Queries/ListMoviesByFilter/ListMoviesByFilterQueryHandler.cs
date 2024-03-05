using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Errors;

namespace MovieGallery.Application.Movies.Queries.ListMoviesByFilter;

public class ListMoviesByFilterQueryHandler(IMovieRepository movieRepository)
    : IRequestHandler<ListMoviesByFilterQuery, Result<List<MovieResult>>>
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public async Task<Result<List<MovieResult>>> Handle(
        ListMoviesByFilterQuery query,
        CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetByFilter(
            query.Filter,
            cancellationToken);

        return (movies!.Count == 0)
            ? Result.Failure<List<MovieResult>>(
                    DomainErrors.Movie.MovieOrMoviesNotFoundWithThatName(query.Filter))
            : movies!.Select(movie => new MovieResult(movie))
                .ToList();
    }
}