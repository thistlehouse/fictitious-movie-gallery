using MediatR;

using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Common;

namespace MovieGallery.Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand(
    string Year,
    string Name,
    string Classification,
    List<string> Cast,
    int Duration,
    string ImageUrl,
    string Synopsis,
    string Category) : IRequest<Result<MovieResult>>;