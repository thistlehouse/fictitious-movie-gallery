using Microsoft.EntityFrameworkCore;

using MovieGallery.Domain.Domain.Movies;

namespace MovieGallery.Infrastructure.Persistence;

public class MovieGalleryDbContext(
    DbContextOptions<MovieGalleryDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MovieGalleryDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}