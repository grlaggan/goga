using MediatR;
using Goga.Backend.Application.Interfaces;

namespace Goga.Backend.Application.Courses.Queries;

public sealed record GetCourseQuery(Guid CourseId) : IRequest<CourseResult?>;

public sealed class GetCourseQueryHandler(ICourseRepository courses)
    : IRequestHandler<GetCourseQuery, CourseResult?>
{
    public async Task<CourseResult?> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await courses.GetByIdAsync(request.CourseId, cancellationToken);
        return course is null ? null : GetCoursesQueryHandler.Map(course);
    }
}
