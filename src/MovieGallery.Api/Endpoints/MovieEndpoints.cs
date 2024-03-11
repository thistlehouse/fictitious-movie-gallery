using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using MovieGallery.Application.Movies.Commands.AddRating;
using MovieGallery.Application.Movies.Commands.CreateMovie;
using MovieGallery.Application.Movies.Queries.ListMovieById;
using MovieGallery.Application.Movies.Queries.ListMoviesByFilter;
using MovieGallery.Contracts;
using MovieGallery.Contracts.Movies;

namespace MovieGallery.Api.Endpoints.Movies;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("movies").WithTags("Movies");

        group.MapPost(
            "/new",
            async (
                CreateMovieRequest request,
                IMapper mapper,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<CreateMovieCommand>(request);
                var result = await sender.Send(command, cancellationToken);
                var response = mapper.Map<MovieResponse>(result);

                return response;
            })
        .RequireAuthorization()
        .WithOpenApi();

        group.MapGet(
            "/details/{id}",
            async (
                Guid id,
                IMapper mapper,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = new ListMovieByIdQuery(id);
                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(mapper.Map<MovieResponse>(result.Value))
                    : Results.BadRequest(result.Error);
            })
        .WithOpenApi();

        group.MapGet(
            "/search",
            async (
                [FromQuery] string? filter,
                IMapper mapper,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var query = mapper.Map<ListMoviesByFilterQuery>(filter!);
                var result = await sender.Send(query, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok(result.Value.Select(
                        r => mapper.Map<MovieResponse>(r)).ToList())
                    : Results.BadRequest(result.Error);
            })
        .WithOpenApi();

        group.MapPatch(
            "/rating",
            async (
                AddRatingRequest request,
                IMapper mapper,
                ISender sender,
                CancellationToken cancellationToken) =>
            {
                var command = mapper.Map<AddRatingCommand>(request);
                var result = await sender.Send(command, cancellationToken);

                return result.IsSuccess
                    ? Results.Ok()
                    : Results.BadRequest(result.Error);
            })
        .WithOpenApi();
    }
}