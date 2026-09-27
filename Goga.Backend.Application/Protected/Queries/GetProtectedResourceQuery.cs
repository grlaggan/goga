using Goga.Backend.Application.Interfaces;
using MediatR;

namespace Goga.Backend.Application.Protected.Queries;

public sealed record GetProtectedResourceQuery : IRequest<ProtectedResourceResult>;

public sealed record ProtectedResourceResult(string Message, string? User);

public sealed class GetProtectedResourceQueryHandler(ICurrentUserService currentUser)
    : IRequestHandler<GetProtectedResourceQuery, ProtectedResourceResult>
{
    public Task<ProtectedResourceResult> Handle(
        GetProtectedResourceQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(new ProtectedResourceResult(
            "Доступ разрешён: JWT токен действителен.", currentUser.Email));
    }
}
