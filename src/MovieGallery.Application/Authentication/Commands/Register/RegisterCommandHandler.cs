using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Movies.Users;

namespace MovieGallery.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtGenerator jwtGenerator)
    : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;

    public async Task<AuthenticationResult> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

        await _userRepository.AddAsync(user, cancellationToken);

        var token = _jwtGenerator.GenerateToken(user);

        var userResult = new AuthenticationResult(user, token);

        return userResult;
    }
}