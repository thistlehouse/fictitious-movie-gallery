using Mapster;

using MovieGallery.Application.Movies.Commands.CreateMovie;
using MovieGallery.Application.Movies.Common;
using MovieGallery.Application.Movies.Queries.ListMoviesByFilter;
using MovieGallery.Contracts.Movies;

namespace MovieGallery.Api.Mapping;

public class MovieMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMovieRequest, CreateMovieCommand>();

        config.NewConfig<string, ListMoviesByFilterQuery>()
            .MapWith(src => new ListMoviesByFilterQuery(src));

        config.NewConfig<MovieResult, MovieResponse>()
            .Map(dest => dest.Id, src => src.Movie.Id.ToString())
            .Map(dest => dest, src => src.Movie);
    }
}