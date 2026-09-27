namespace Goga.Backend.Application.Interfaces;

public interface IJwtTokenService
{
    AccessTokenResult Create(string email, string? group = null, string? firstName = null, string? lastName = null);
}

public sealed record AccessTokenResult(string AccessToken, DateTime ExpiresAt);
