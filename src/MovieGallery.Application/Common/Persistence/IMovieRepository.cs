using MovieGallery.Domain.Domain.Movies;

namespace MovieGallery.Application.Common.Persistence;

public interface IMovieRepository
{
    public Task AddAsync(Movie movie, CancellationToken cancellationToken);
    public Task<Movie?> GetById(Guid id, CancellationToken cancellationToken);
    public Task<List<Movie>?> GetByFilter(string query, CancellationToken cancellationToken);
    public Task PatchAsync(Movie movie, CancellationToken cancellationToken);
}