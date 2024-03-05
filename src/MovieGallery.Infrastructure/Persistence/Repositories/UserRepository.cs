using Microsoft.EntityFrameworkCore;

using MovieGallery.Application.Common.Persistence;
using MovieGallery.Domain.Users;

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

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .SingleOrDefaultAsync(user => user.Email == email);
    }
}