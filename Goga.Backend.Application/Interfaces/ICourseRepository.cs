using Goga.Backend.Domain.Courses;
using Goga.Backend.Domain.Users;

namespace Goga.Backend.Application.Interfaces;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync(CancellationToken cancellationToken);
    Task<Course?> GetByIdAsync(Guid courseId, CancellationToken cancellationToken);
    Task<bool> EnrollAsync(User user, Guid courseId, CancellationToken cancellationToken);
}
