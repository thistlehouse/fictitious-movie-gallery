using MediatR;

using Microsoft.AspNetCore.Http.HttpResults;

using MovieGallery.Application.Authentication.Commands.Register;
using MovieGallery.Contracts.Authentication;

namespace MovieGallery.Api.Endpoints.Users;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("auth").WithTags("Auth");

        group.MapPost("/register", async (
            RegisterRequest request,
            ISender sender) =>
            {
                var command = new RegisterCommand(
                    request.FirstName,
                    request.LastName,
                    request.Email,
                    request.Password);

                var result = await sender.Send(command);

                var response = new AuthenticationResponse(
                    result.User.FirstName,
                    result.User.LastName,
                    result.User.Email,
                    result.Token);

                return response;
            })
            .WithName("create-user")
            .WithOpenApi();
    }
}