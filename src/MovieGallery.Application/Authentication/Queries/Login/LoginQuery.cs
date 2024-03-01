using MediatR;

using MovieGallery.Application.Authentication.Common;

namespace MovieGallery.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;