namespace Goga.Backend.Application.Interfaces;

public interface ICurrentUserService
{
    string? Subject { get; }
    string? Email { get; }
    string? Group { get; }
    string? FirstName { get; }
    string? LastName { get; }
}
