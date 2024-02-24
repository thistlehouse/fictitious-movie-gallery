using MediatR;

using MovieGallery.Application.Movies.Common;
using MovieGallery.Domain.Domain.Movies;

namespace MovieGallery.Application.Movies.Queries.ListMovies;

public record ListMoviesQuery() : IRequest<List<MovieResult>>;