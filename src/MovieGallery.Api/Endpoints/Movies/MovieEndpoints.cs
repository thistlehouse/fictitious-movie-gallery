using MediatR;

using Microsoft.AspNetCore.Mvc;

using MovieGallery.Application.Movies.Commands.CreateMovie;
using MovieGallery.Application.Movies.Queries.ListMovieById;
using MovieGallery.Application.Movies.Queries.ListMovies;
using MovieGallery.Application.Movies.Queries.ListMoviesByFilter;
using MovieGallery.Contracts.Movies;

namespace MovieGallery.Api.Endpoints.Movies;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("movies");

        group.MapPost(
            "/new",
            async (
                CreateMovieRequest createMovieRequest,
                ISender sender,
                CancellationToken cancellationToken) =>
        {
            var command = new CreateMovieCommand(
                createMovieRequest.Name,
                createMovieRequest.Classification,
                createMovieRequest.Cast,
                createMovieRequest.Duration,
                createMovieRequest.ImageUrl,
                createMovieRequest.Synopsis,
                createMovieRequest.Category,
                createMovieRequest.Rating);

            var result = await sender.Send(command, cancellationToken);

            var response = new CreateMovieResponse(
                result.Movie.Name,
                result.Movie.Classification,
                result.Movie.Cast,
                result.Movie.Duration,
                result.Movie.ImageUrl.ToString(),
                result.Movie.Synopsis,
                result.Movie.Category.ToString(),
                result.Movie.Rating);

            return response;
        })
        .WithName("create-movie")
        .WithOpenApi();

        group.MapGet(
            "/all",
            async (
                ISender sender,
                CancellationToken cancellationToken) =>
        {
            var query = new ListMoviesQuery();

            var result = await sender.Send(query, cancellationToken);

            var response = result.Select(
                r => new ListMovieResponse(
                    r.Movie.Id.ToString(),
                    r.Movie.Name,
                    r.Movie.Classification,
                    r.Movie.Cast,
                    r.Movie.Duration,
                    r.Movie.ImageUrl.ToString(),
                    r.Movie.Synopsis,
                    r.Movie.Category.ToString(),
                    r.Movie.Rating))
                .ToList();

            return response;
        })
        .WithName("list-movies")
        .WithOpenApi();

        group.MapGet(
            "/details/{id}",
            async (
                Guid id,
                ISender sender,
                CancellationToken cancellationToken) =>
        {
            var query = new ListMovieByIdQuery(id);

            var result = await sender.Send(query, cancellationToken);

            var response = new ListMovieResponse(
                result.Movie.Id.ToString(),
                result.Movie.Name,
                result.Movie.Classification,
                result.Movie.Cast,
                result.Movie.Duration,
                result.Movie.ImageUrl.ToString(),
                result.Movie.Synopsis,
                result.Movie.Category.ToString(),
                result.Movie.Rating);

            return response;
        })
        .WithName("list-movie")
        .WithOpenApi();

        group.MapGet(
            "/search",
            async (
                [FromQuery] string? filter,
                ISender sender,
                CancellationToken cancellationToken) =>
        {
            var request = new ListMoviesByFilterRequest(filter!);
            var query = new ListMoviesByFilterQuery(request.Filter);

            var result = await sender.Send(query, cancellationToken);

            var response = result.Select(
                r => new ListMovieResponse(
                    r.Movie.Id.ToString(),
                    r.Movie.Name,
                    r.Movie.Classification,
                    r.Movie.Cast,
                    r.Movie.Duration,
                    r.Movie.ImageUrl.ToString(),
                    r.Movie.Synopsis,
                    r.Movie.Category.ToString(),
                    r.Movie.Rating))
                .ToList();

            return response;
        })
        .WithName("list-movies-by-filter")
        .WithOpenApi();
    }
}