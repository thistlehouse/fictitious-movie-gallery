using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Domain.Movies;
using MovieGallery.Domain.Movies.Enums;

namespace MovieGallery.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler(
    IMovieRepository movieRepository)
    : IRequestHandler<CreateMovieCommand, MovieResult>
{
    public async Task<MovieResult> Handle(
        CreateMovieCommand request,
        CancellationToken cancellationToken)
    {
        if (!Enum.TryParse(request.Category, ignoreCase: true, out MovieCategory category))
        {
            throw new ArgumentException("MovieCategory is not correctly specified");
        }

        var movie = Movie.Create(
            request.Name,
            request.Classification,
            request.Cast,
            request.Duration,
            new Uri("image.Urls.Get"),
            request.Synopsis,
            category,
            request.Rating);

        await movieRepository.AddMovieAsync(movie, cancellationToken);

        var result = new MovieResult(movie);

        return result;
    }
}