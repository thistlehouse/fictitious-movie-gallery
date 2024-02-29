using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Common.Services;
using MovieGallery.Infrastructure.Authentication;
using MovieGallery.Infrastructure.Persistence;
using MovieGallery.Infrastructure.Persistence.Repositories;
using MovieGallery.Infrastructure.Services;

namespace MovieGallery.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence()
            .AddAuth();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddSingleton(provider =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieGalleryDbContext>();

            optionsBuilder.UseInMemoryDatabase("MovieGallery");

            return new MovieGalleryDbContext(optionsBuilder.Options);
        });

        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}