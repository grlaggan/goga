using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Courses;
using Goga.Backend.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Goga.Backend.Persistence.Courses;

public sealed class CourseRepository(AppDbContext db) : ICourseRepository
{
    public async Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken) =>
        await db.Courses.Include(course => course.Sections).AsNoTracking().ToListAsync(cancellationToken);

    public Task<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken) =>
        db.Courses.Include(course => course.Sections)
            .AsNoTracking().SingleOrDefaultAsync(course => course.Id == courseId, cancellationToken);

    public async Task<bool> EnrollAsync(User user, Guid courseId, CancellationToken cancellationToken)
    {
        if (await db.UserCourses.AnyAsync(x => x.UserId == user.Id && x.CourseId == courseId, cancellationToken))
            return false;

        db.UserCourses.Add(new UserCourse(user.Id, courseId));
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
