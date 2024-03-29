using MovieGallery.Domain.Movies.Users;

namespace MovieGallery.Application.Common.Persistence;

public interface IUserRepository
{
    public Task AddAsync(User user, CancellationToken cancellationToken);
}