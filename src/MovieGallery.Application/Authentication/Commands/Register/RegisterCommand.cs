using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Domain.Common;

namespace MovieGallery.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<Result<AuthenticationResult>>;