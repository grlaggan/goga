using Goga.Backend.Domain.Timetables;

namespace Goga.Backend.Application.Interfaces;

public interface ITimetableRepository
{
    Task<IReadOnlyList<ScheduleEntry>> GetAsync(
        string group, DayOfWeek dayOfWeek, WeekParity weekParity, CancellationToken cancellationToken);
}
