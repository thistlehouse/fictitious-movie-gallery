using MovieGallery.Infrastructure.Persistence;
using MovieGallery.Infrastructure.Persistence.Mock;

namespace MovieGallery.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication SeedMoviesData(this WebApplication app, int count)
    {
        var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MovieGalleryDbContext>();

        if (!context.Database.EnsureCreated())
        {
            throw new InvalidOperationException("Database was not created");
        }

        MockMovies.GenerateMovies(context, count);

        return app;
    }
}