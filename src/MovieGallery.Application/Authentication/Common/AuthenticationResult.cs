using MovieGallery.Domain.Users;

namespace MovieGallery.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);