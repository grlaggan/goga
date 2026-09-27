using Goga.Backend.Application.Interfaces;
using MediatR;

namespace Goga.Backend.Application.Courses.Queries;

public sealed record GetCoursesQuery : IRequest<IReadOnlyList<CourseResult>>;
public sealed record CourseResult(Guid Id, string Name, IReadOnlyList<SectionResult> Sections);
public sealed record SectionResult(Guid Id, string Name, string PdfPath);

public sealed class GetCoursesQueryHandler(ICourseRepository courses)
    : IRequestHandler<GetCoursesQuery, IReadOnlyList<CourseResult>>
{
    public async Task<IReadOnlyList<CourseResult>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var items = await courses.GetAllAsync(cancellationToken);
        return items.Select(Map).ToList();
    }

    internal static CourseResult Map(Domain.Courses.Course course) =>
        new(course.Id, course.Name, course.Sections
            .Select(section => new SectionResult(section.Id, section.Name, section.PdfPath))
            .ToList());
}
