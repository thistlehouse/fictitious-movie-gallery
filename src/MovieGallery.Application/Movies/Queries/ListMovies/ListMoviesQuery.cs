using MediatR;

using MovieGallery.Application.Movies.Common;

namespace MovieGallery.Application.Movies.Queries.ListMovies;

public record ListMoviesQuery() : IRequest<List<MovieResult>>;