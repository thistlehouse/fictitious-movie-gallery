using Mapster;

using MovieGallery.Application.Movies.Commands.CreateMovie;
using MovieGallery.Application.Movies.Common;
using MovieGallery.Application.Movies.Queries.ListMoviesByFilter;
using MovieGallery.Contracts.Movies;

namespace MovieGallery.Api.Mapping.Movies;

public class MovieMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateMovieRequest, CreateMovieCommand>();
        config.NewConfig<ListMoviesByFilterRequest, ListMoviesByFilterQuery>();
        config.NewConfig<MovieResult, CreateMovieResponse>()
            .Map(dest => dest.Year, src => src.Movie.Year)
            .Map(dest => dest.Name, src => src.Movie.Name)
            .Map(dest => dest.Classification, src => src.Movie.Classification)
            .Map(dest => dest.Cast, src => src.Movie.Cast)
            .Map(dest => dest.Duration, src => src.Movie.Duration)
            .Map(dest => dest.ImageUrl, src => src.Movie.ImageUrl)
            .Map(dest => dest.Synopsis, src => src.Movie.Synopsis)
            .Map(dest => dest.Category, src => src.Movie.Category)
            .Map(dest => dest.RatingValue, src => src.Movie.RatingValue);

        config.NewConfig<MovieResult, ListMovieResponse>()
            .Map(dest => dest.Id, src => src.Movie.Id.ToString())
            .Map(dest => dest, src => src.Movie);
    }
}