using MediatR;

using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMoviesByFilter;

public record ListMoviesByFilterQuery(string Query)
    : IRequest<List<MovieResult>>;