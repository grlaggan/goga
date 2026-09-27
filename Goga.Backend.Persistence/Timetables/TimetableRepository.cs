using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Timetables;
using Microsoft.EntityFrameworkCore;

namespace Goga.Backend.Persistence.Timetables;

public sealed class TimetableRepository(AppDbContext db) : ITimetableRepository
{
    public async Task<IReadOnlyList<ScheduleEntry>> GetAsync(
        string group, DayOfWeek dayOfWeek, WeekParity weekParity, CancellationToken cancellationToken) =>
        await db.ScheduleEntries.AsNoTracking()
            .Where(entry => entry.Group == group && entry.DayOfWeek == dayOfWeek && entry.WeekParity == weekParity)
            .OrderBy(entry => entry.Number)
            .ToListAsync(cancellationToken);
}
