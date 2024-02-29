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
        CreateMovieCommand command,
        CancellationToken cancellationToken)
    {
        if (!Enum.TryParse(command.Category, ignoreCase: true, out MovieCategory category))
        {
            throw new ArgumentException("MovieCategory is not correctly specified");
        }

        var movie = Movie.Create(
            command.Year,
            command.Name,
            command.Classification,
            command.Cast,
            command.Duration,
            new Uri(command.ImageUrl),
            command.Synopsis,
            category);

        await movieRepository.AddMovieAsync(movie, cancellationToken);

        var result = new MovieResult(movie);

        return result;
    }
}