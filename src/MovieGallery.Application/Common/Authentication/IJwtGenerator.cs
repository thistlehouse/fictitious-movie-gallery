using MovieGallery.Domain.Movies.Users;

namespace MovieGallery.Application.Common.Authentication;

public interface IJwtGenerator
{
    public string GenerateToken(User user);
}