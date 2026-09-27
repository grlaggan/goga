using Goga.Backend.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Goga.Backend.Persistence.News;

public sealed class NewsRepository(AppDbContext db) : INewsRepository
{
    public async Task<IReadOnlyList<Goga.Backend.Domain.News.News>> GetAllAsync(CancellationToken cancellationToken) =>
        await db.News.AsNoTracking().OrderByDescending(item => item.Id).ToListAsync(cancellationToken);
}
