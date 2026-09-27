using Goga.Backend.Domain.Courses;
using Goga.Backend.Domain.Sports;

namespace Goga.Backend.Domain.Users;

public sealed class User
{
    private User() { }

    public User(Guid id, string identityServerSubject, string email, string group,
        string firstName, string lastName, string passwordHash)
    {
        Id = id;
        IdentityServerSubject = identityServerSubject;
        Email = email;
        Group = group;
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string IdentityServerSubject { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Group { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public ICollection<UserCourse> Courses { get; private set; } = new List<UserCourse>();
    public ICollection<UserSportEnrollment> SportEnrollments { get; private set; } = new List<UserSportEnrollment>();
}
