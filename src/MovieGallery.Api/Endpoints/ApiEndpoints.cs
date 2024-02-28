using MovieGallery.Api.Endpoints.Movies;
using MovieGallery.Api.Endpoints.Users;

namespace MovieGallery.Api.Endpoints;

public static class ApiEndpoints
{
    public static void MapApiEndpoints(this IEndpointRouteBuilder builder)
    {
        AuthenticationEndpoints.MapAuthenticationEndpoints(builder);
        MovieEndpoints.MapMovieEndpoints(builder);
    }
}