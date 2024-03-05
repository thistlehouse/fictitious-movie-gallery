using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Errors;
using MovieGallery.Domain.Users;

namespace MovieGallery.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtGenerator jwtGenerator)
    : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;

    public async Task<Result<AuthenticationResult>> Handle(
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmailAsync(command.Email, cancellationToken) is not null)
        {
            return Result.Failure<AuthenticationResult>(
                DomainErrors.User.EmailAlreadyRegistered);
        }

        var user = User.Create(
            Guid.NewGuid(),
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

        await _userRepository.AddAsync(user, cancellationToken);

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}