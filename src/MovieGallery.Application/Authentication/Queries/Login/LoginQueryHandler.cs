using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Errors;
using MovieGallery.Domain.Users;

namespace MovieGallery.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IUserRepository userRepository,
    IJwtGenerator jwtGenerator)
    : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;

    public async Task<Result<AuthenticationResult>> Handle(
        LoginQuery query,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(query.Email, cancellationToken) is not User user)
        {
            return Result.Failure<AuthenticationResult>(
                DomainErrors.User.InvalidCredentials);
        }

        if (user.Password != query.Password)
        {
            return Result.Failure<AuthenticationResult>(
                DomainErrors.User.InvalidCredentials);
        }

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}