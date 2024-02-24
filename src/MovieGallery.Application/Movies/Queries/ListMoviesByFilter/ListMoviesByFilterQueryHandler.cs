using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMoviesByFilter;

public class ListMoviesByFilterQueryHandler(IMovieRepository movieRepository)
    : IRequestHandler<ListMoviesByFilterQuery, List<MovieResult>>
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public async Task<List<MovieResult>> Handle(
        ListMoviesByFilterQuery query,
        CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetByFilter(
            query.Query,
            cancellationToken);

        return movies!.Select(movie => new MovieResult(movie))
            .ToList();
    }
}