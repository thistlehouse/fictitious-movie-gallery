using MovieGallery.Api.Endpoints.Movies;

namespace MovieGallery.Api.Endpoints;

public static class ApiEndpoints
{
    public static void MapApiEndpoints(this IEndpointRouteBuilder builder)
    {
        MovieEndpoints.MapMovieEndpoints(builder);
    }
}