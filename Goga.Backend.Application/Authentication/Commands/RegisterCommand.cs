using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Users;
using MediatR;

namespace Goga.Backend.Application.Authentication.Commands;

public sealed record RegisterCommand(
    string Email,
    string Password,
    string Group,
    string FirstName,
    string LastName) : IRequest<LoginResult?>;

public sealed class RegisterCommandHandler(
    IUserRepository users,
    IPasswordHasher passwordHasher,
    IJwtTokenService jwtTokenService) : IRequestHandler<RegisterCommand, LoginResult?>
{
    public async Task<LoginResult?> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        if (!email.Contains('@') || request.Password.Length < 8 ||
            string.IsNullOrWhiteSpace(request.Group) ||
            string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            await users.FindByEmailAsync(email, cancellationToken) is not null)
            return null;

        var group = request.Group.Trim();
        var firstName = request.FirstName.Trim();
        var lastName = request.LastName.Trim();
        var user = new User(Guid.NewGuid(), email, email, group, firstName, lastName,
            passwordHasher.Hash(request.Password));
        await users.AddAsync(user, cancellationToken);

        var token = jwtTokenService.Create(email, group, firstName, lastName);
        return new LoginResult(token.AccessToken, "Bearer", token.ExpiresAt);
    }
}
