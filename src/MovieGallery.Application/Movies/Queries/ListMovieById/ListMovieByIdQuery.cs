using MediatR;

using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Common;

namespace MovieGallery.Application.Movies.Queries.ListMovieById;

public record ListMovieByIdQuery(Guid Id) : IRequest<Result<MovieResult>>;