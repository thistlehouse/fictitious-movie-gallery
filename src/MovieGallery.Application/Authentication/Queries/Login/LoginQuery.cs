using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Domain.Common;

namespace MovieGallery.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) :
    IRequest<Result<AuthenticationResult>>;