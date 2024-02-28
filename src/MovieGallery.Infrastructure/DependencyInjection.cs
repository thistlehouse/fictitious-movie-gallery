using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Infrastructure.Authentication;
using MovieGallery.Infrastructure.Persistence;
using MovieGallery.Infrastructure.Persistence.Repositories;

namespace MovieGallery.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddPersistence()
            .AddAuth(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<MovieGalleryDbContext>(
            options => options.UseInMemoryDatabase("MovieGallery"));

        services.AddScoped<IMovieRepository, MovieRepository>();

        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();

        var jwtOptions = new JwtOptions();

        configuration.Bind(JwtOptions.Section, jwtOptions);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters =
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtOptions.Secret)),
                });

        return services;
    }
}