using System.Security.Cryptography;
using System.Text;
using Goga.Backend.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Goga.Backend.Domain.Users;

namespace Goga.Backend.Application.Authentication.Commands;

public sealed record LoginCommand(string Email, string Password) : IRequest<LoginResult?>;

public sealed record LoginResult(string AccessToken, string TokenType, DateTime ExpiresAt);

public sealed class LoginCommandHandler(
    IConfiguration configuration,
    IUserRepository users,
    IPasswordHasher passwordHasher,
    IJwtTokenService jwtTokenService) : IRequestHandler<LoginCommand, LoginResult?>
{
    public async Task<LoginResult?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var user = await users.FindByEmailAsync(email, cancellationToken);
        var validDatabaseUser = user is not null && passwordHasher.Verify(request.Password, user.PasswordHash);
        var validDevelopmentUser = CryptographicEquals(request.Email, configuration["Auth:User:Email"]) &&
            CryptographicEquals(request.Password, configuration["Auth:User:Password"]);

        if (!validDatabaseUser && !validDevelopmentUser)
        {
            return null;
        }

        var token = user is null
            ? jwtTokenService.Create(email)
            : jwtTokenService.Create(email, user.Group, user.FirstName, user.LastName);
        return new LoginResult(token.AccessToken, "Bearer", token.ExpiresAt);
    }

    private static bool CryptographicEquals(string value, string? expected)
    {
        if (expected is null || value.Length != expected.Length)
            return false;

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(expected));
    }
}
