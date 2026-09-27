using Goga.Backend.Domain.Sports;

namespace Goga.Backend.Application.Interfaces;

public interface ISportSectionRepository
{
    Task<string?> GetUserEnrollmentAsync(string userEmail, CancellationToken cancellationToken);
    Task<bool> EnrollAsync(string sectionName, string userEmail, CancellationToken cancellationToken);
}
