using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Common.Services.OpenJourney;
using MovieGallery.Infrastructure.Persistence;
using MovieGallery.Infrastructure.Persistence.Repositories;
using MovieGallery.Infrastructure.Services.OpenJourney;

namespace MovieGallery.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<MovieGalleryDbContext>(
            options => options.UseInMemoryDatabase("MovieGallery"));

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IOpenAiImageService, OpenAiImageService>();

        return services;
    }
}