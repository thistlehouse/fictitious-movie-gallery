using MediatR;

using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMovieById;

public record ListMovieByIdQuery(Guid Id) : IRequest<MovieResult>;