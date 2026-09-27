using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Goga.Backend.Persistence.Users;

public sealed class UserRepository(AppDbContext db) : IUserRepository
{
    public Task<User?> FindByEmailAsync(string email, CancellationToken cancellationToken) =>
        db.Users.SingleOrDefaultAsync(user => user.Email == email, cancellationToken);

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync(cancellationToken);
    }
}
