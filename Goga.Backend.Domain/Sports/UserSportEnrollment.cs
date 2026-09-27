using Goga.Backend.Domain.Users;

namespace Goga.Backend.Domain.Sports;

public sealed class UserSportEnrollment
{
    private UserSportEnrollment() { }

    public UserSportEnrollment(Guid id, Guid userId, string sectionName, DateTime enrolledAt)
    {
        Id = id;
        UserId = userId;
        SectionName = sectionName;
        EnrolledAt = enrolledAt;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string SectionName { get; private set; } = null!;
    public DateTime EnrolledAt { get; private set; }
    public User User { get; private set; } = null!;
}
