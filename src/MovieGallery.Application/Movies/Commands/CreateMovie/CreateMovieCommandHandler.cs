using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Domain.Movies;
using MovieGallery.Domain.Errors;
using MovieGallery.Domain.Movies.Enums;

namespace MovieGallery.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandHandler(
    IMovieRepository movieRepository)
    : IRequestHandler<CreateMovieCommand, Result<MovieResult>>
{
    public async Task<Result<MovieResult>> Handle(
        CreateMovieCommand command,
        CancellationToken cancellationToken)
    {
        if (!Enum.TryParse(command.Category, ignoreCase: true, out MovieCategory category))
        {
            return Result.Failure<MovieResult>(
                DomainErrors.Movie.MovieCategoryIsNotCorrectlySpecified(
                    command.Category));
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

        await movieRepository.AddAsync(movie, cancellationToken);

        return new MovieResult(movie);
    }
}