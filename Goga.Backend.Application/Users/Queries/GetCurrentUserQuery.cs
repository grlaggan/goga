using Goga.Backend.Application.Interfaces;
using MediatR;

namespace Goga.Backend.Application.Users.Queries;

public sealed record GetCurrentUserQuery : IRequest<CurrentUserResult>;

public sealed record CurrentUserResult(
    string? Subject,
    string? Email,
    string? Group,
    string? FirstName,
    string? LastName);

public sealed class GetCurrentUserQueryHandler(ICurrentUserService currentUser)
    : IRequestHandler<GetCurrentUserQuery, CurrentUserResult>
{
    public Task<CurrentUserResult> Handle(
        GetCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(new CurrentUserResult(
            currentUser.Subject,
            currentUser.Email,
            currentUser.Group,
            currentUser.FirstName,
            currentUser.LastName));
    }
}
