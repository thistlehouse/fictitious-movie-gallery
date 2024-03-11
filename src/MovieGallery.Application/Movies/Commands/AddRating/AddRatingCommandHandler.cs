using MediatR;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Domain.Movies;
using MovieGallery.Domain.Errors;

namespace MovieGallery.Application.Movies.Commands.AddRating;

public class AddRatingCommandHandler(IMovieRepository movieRepository)
    : IRequestHandler<AddRatingCommand, Result>
{
    private readonly IMovieRepository _movieRepository = movieRepository;

    public async Task<Result> Handle(
        AddRatingCommand command,
        CancellationToken cancellationToken)
    {
        if (await _movieRepository.GetById(command.Id, cancellationToken) is not Movie movie)
        {
            return Result.Failure(
                DomainErrors.Movie.MovieNotFound(command.Id));
        }

        movie.AddNewRating(command.Rating);

        await _movieRepository.PatchAsync(movie, cancellationToken);

        return Result.Success();
    }
}