using MovieGallery.Domain.Users;

namespace MovieGallery.Application.Common.Services;

public interface IEmailService
{
    public void SendConfirmRegistrationMessage(User user);
}