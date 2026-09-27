namespace Goga.Backend.Application.Interfaces;

public interface INewsRepository
{
    Task<IReadOnlyList<Goga.Backend.Domain.News.News>> GetAllAsync(CancellationToken cancellationToken);
}
