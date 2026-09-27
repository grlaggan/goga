namespace Goga.Backend.Domain.Courses;

public sealed class Section
{
    private Section() { }

    public Section(Guid id, Guid courseId, string name, string pdfPath)
    {
        Id = id;
        CourseId = courseId;
        Name = name;
        PdfPath = pdfPath;
    }

    public Guid Id { get; private set; }
    public Guid CourseId { get; private set; }
    public string Name { get; private set; } = null!;
    public string PdfPath { get; private set; } = null!;
    public Course Course { get; private set; } = null!;
}
