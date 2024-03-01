using MapsterMapper;

using MediatR;

using MovieGallery.Application.Authentication.Commands.Register;
using MovieGallery.Application.Authentication.Queries.Login;
using MovieGallery.Contracts.Authentication;

namespace MovieGallery.Api.Endpoints.Users;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("auth").WithTags("Auth");

        group.MapPost("/register", async (
            RegisterRequest request,
            IMapper mapper,
            ISender sender) =>
            {
                var command = mapper.Map<RegisterCommand>(request);
                var result = await sender.Send(command);
                var response = mapper.Map<AuthenticationResponse>(result);

                return response;
            })
            .WithName("create-user")
            .WithOpenApi();

        group.MapPost(
            "/login",
            async (
                LoginRequest request,
                IMapper mapper,
                ISender sender) =>
            {
                var query = mapper.Map<LoginQuery>(request);
                var result = await sender.Send(query);
                var response = mapper.Map<AuthenticationResponse>(result);

                return response;
            });
    }
}