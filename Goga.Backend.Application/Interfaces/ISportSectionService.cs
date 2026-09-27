using Goga.Backend.Domain.Sports;

namespace Goga.Backend.Application.Interfaces;

public interface ISportSectionService
{
    Task<IReadOnlyList<SportSection>> GetAllAsync(CancellationToken cancellationToken);
    Task<string?> GetUserEnrollmentAsync(string userEmail, CancellationToken cancellationToken);
    Task<bool> EnrollAsync(string sectionName, string userEmail, CancellationToken cancellationToken);
}
