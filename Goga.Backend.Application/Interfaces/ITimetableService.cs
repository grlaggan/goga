using Goga.Backend.Domain.Timetables;

namespace Goga.Backend.Application.Interfaces;

public interface ITimetableService
{
    Task<Timetable> GetForTodayAsync(string group, CancellationToken cancellationToken);
    Task<Timetable> GetForTomorrowAsync(string group, CancellationToken cancellationToken);
}
