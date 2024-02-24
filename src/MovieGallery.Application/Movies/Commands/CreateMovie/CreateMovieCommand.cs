using MediatR;

using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Commands.CreateMovie;

public record CreateMovieCommand(
    string Name,
    string Classification,
    List<string> Cast,
    int Duration,
    string ImageUrl,
    string Synopsis,
    string Category,
    decimal Rating) : IRequest<MovieResult>;