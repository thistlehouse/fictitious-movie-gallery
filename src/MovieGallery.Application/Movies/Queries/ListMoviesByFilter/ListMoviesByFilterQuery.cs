using MediatR;

using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Common;

namespace MovieGallery.Application.Movies.Queries.ListMoviesByFilter;

public record ListMoviesByFilterQuery(string Filter)
    : IRequest<Result<List<MovieResult>>>;