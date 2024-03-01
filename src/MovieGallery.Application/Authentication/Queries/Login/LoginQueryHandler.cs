using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Movies.Users;

namespace MovieGallery.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IUserRepository userRepository,
    IJwtGenerator jwtGenerator)
    : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;

    public async Task<AuthenticationResult> Handle(
        LoginQuery query,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(
            query.Email,
            cancellationToken) is not User user)
        {
            throw new Exception("User not found");
        }

        if (user.Password != query.Password)
        {
            throw new Exception("Password doest not match");
        }

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}