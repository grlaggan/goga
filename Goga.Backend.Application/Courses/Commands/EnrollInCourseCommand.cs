using Goga.Backend.Application.Interfaces;
using MediatR;

namespace Goga.Backend.Application.Courses.Commands;

public sealed record EnrollInCourseCommand(Guid CourseId) : IRequest<EnrollResult>;
public sealed record EnrollResult(bool Success, string Message);

public sealed class EnrollInCourseCommandHandler(
    ICurrentUserService currentUser,
    IUserRepository users,
    ICourseRepository courses) : IRequestHandler<EnrollInCourseCommand, EnrollResult>
{
    public async Task<EnrollResult> Handle(EnrollInCourseCommand request, CancellationToken cancellationToken)
    {
        if (currentUser.Email is null)
            return new(false, "Пользователь не найден.");

        var user = await users.FindByEmailAsync(currentUser.Email, cancellationToken);
        if (user is null)
            return new(false, "Пользователь не найден.");

        if (await courses.GetByIdAsync(request.CourseId, cancellationToken) is null)
            return new(false, "Курс не найден.");

        var enrolled = await courses.EnrollAsync(user, request.CourseId, cancellationToken);
        return enrolled
            ? new(true, "Вы записались на курс.")
            : new(false, "Вы уже записаны на этот курс.");
    }
}
