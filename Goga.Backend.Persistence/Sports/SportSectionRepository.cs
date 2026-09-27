using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Sports;
using Goga.Backend.Domain.Users;
using Microsoft.EntityFrameworkCore;


namespace Goga.Backend.Persistence.Sports;

public sealed class SportSectionRepository(AppDbContext db) : ISportSectionRepository
{
    public async Task<string?> GetUserEnrollmentAsync(string userEmail, CancellationToken cancellationToken)
    {
        var user = await db.Users
            .FirstOrDefaultAsync(u => u.Email == userEmail, cancellationToken);

        if (user is null)
            return null;

        var enrollment = await db.UserSportEnrollments
            .FirstOrDefaultAsync(e => e.UserId == user.Id, cancellationToken);

        return enrollment?.SectionName;
    }

    public async Task<bool> EnrollAsync(string sectionName, string userEmail, CancellationToken cancellationToken)
    {
        var user = await db.Users
            .FirstOrDefaultAsync(u => u.Email == userEmail, cancellationToken);

        if (user is null)
            return false;

        var existingEnrollment = await db.UserSportEnrollments
            .FirstOrDefaultAsync(e => e.UserId == user.Id, cancellationToken);

        if (existingEnrollment is not null)
            return false;

        var enrollment = new UserSportEnrollment(Guid.NewGuid(), user.Id, sectionName, DateTime.UtcNow);
        db.UserSportEnrollments.Add(enrollment);
        await db.SaveChangesAsync(cancellationToken);

        return true;
    }
}
