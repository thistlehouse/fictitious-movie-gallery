using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Movies.Users;

namespace MovieGallery.Infrastructure.Persistence.Repositories;

public class UserRepository(MovieGalleryDbContext context)
    : IUserRepository
{
    private readonly MovieGalleryDbContext _context = context;

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}