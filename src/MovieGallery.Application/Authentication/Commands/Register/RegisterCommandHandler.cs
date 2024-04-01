using MediatR;

using MovieGallery.Application.Authentication.Common;
using MovieGallery.Application.Common.Authentication;
using MovieGallery.Application.Common.Persistence;
using MovieGallery.Application.Common.Services;
using MovieGallery.Domain.Common;
using MovieGallery.Domain.Errors;
using MovieGallery.Domain.Users;

namespace MovieGallery.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtGenerator jwtGenerator,
    IEmailService emailService)
    : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtGenerator _jwtGenerator = jwtGenerator;
    private readonly IEmailService _emailService = emailService;

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

        _emailService.SendConfirmRegistrationMessage(user);

        return new AuthenticationResult(user, token);
    }
}