using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMovies;

public class ListMoviesQueryHandler(IMovieRepository movieRepository)
    : IRequestHandler<ListMoviesQuery, List<MovieResult>>
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public async Task<List<MovieResult>> Handle(
        ListMoviesQuery query,
        CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetAll(cancellationToken);

        var result = movies
            .Select(movie => new MovieResult(movie))
            .ToList();

        return result;
    }
}