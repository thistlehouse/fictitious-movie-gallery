using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMovies;

public class ListMoviesQueryHandler(IMovieRepository movieRepository)
    : IRequestHandler<ListMoviesQuery, List<MovieResult>>
{
    public async Task<List<MovieResult>> Handle(
        ListMoviesQuery request,
        CancellationToken cancellationToken)
    {
        var movies = await movieRepository.GetAll(cancellationToken);

        var result = movies
            .Select(movie => new MovieResult(movie))
            .ToList();

        return result;
    }
}