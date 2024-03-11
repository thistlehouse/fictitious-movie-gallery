using Dumpify;

using Microsoft.EntityFrameworkCore;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Domain.Movies;

namespace MovieGallery.Infrastructure.Persistence.Repositories;

public class MovieRepository(MovieGalleryDbContext context) : IMovieRepository
{

    public async Task AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        context.Movies.Add(movie);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Movie?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Movies.SingleOrDefaultAsync(
            m => m.Id == id,
            cancellationToken);
    }

    public async Task<List<Movie>?> GetByFilter(
        string query,
        CancellationToken cancellationToken)
    {
        var movies = await context.Movies
            .Where(movie => string.IsNullOrEmpty(query) ||
                movie.Name.Contains(
                    query,
                    StringComparison.CurrentCultureIgnoreCase))
            .GroupBy(movie => movie.Category)
            .Select(group => new
            {
                Category = group.Key,
                Movies = group.ToList(),
            })
            .ToListAsync(cancellationToken);

        var moviesByCategory = movies.SelectMany(group => group.Movies).ToList();

        return moviesByCategory;
    }

    public async Task PatchAsync(Movie movie, CancellationToken cancellationToken)
    {
        context.Entry(movie).State = EntityState.Modified;

        await context.SaveChangesAsync(cancellationToken);
    }
}