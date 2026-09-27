using Goga.Backend.Domain.Users;

namespace Goga.Backend.Domain.Courses;

public sealed class UserCourse
{
    private UserCourse() { }

    public UserCourse(Guid userId, Guid courseId)
    {
        UserId = userId;
        CourseId = courseId;
        EnrolledAt = DateTime.UtcNow;
    }

    public Guid UserId { get; private set; }
    public Guid CourseId { get; private set; }
    public DateTime EnrolledAt { get; private set; }
    public User User { get; private set; } = null!;
    public Course Course { get; private set; } = null!;
}
