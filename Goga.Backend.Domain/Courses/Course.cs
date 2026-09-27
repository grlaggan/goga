namespace Goga.Backend.Domain.Courses;

public sealed class Course
{
    private Course() { }

    public Course(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public ICollection<Section> Sections { get; private set; } = new List<Section>();
    public ICollection<UserCourse> Enrollments { get; private set; } = new List<UserCourse>();
}
