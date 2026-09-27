using System.Globalization;
using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Timetables;

namespace Goga.Backend.Application.Timetables;

public sealed class TimetableService(ITimetableRepository repository) : ITimetableService
{
    public Task<Timetable> GetForTodayAsync(string group, CancellationToken cancellationToken) =>
        GetAsync(group, DateTime.Today, cancellationToken);

    public Task<Timetable> GetForTomorrowAsync(string group, CancellationToken cancellationToken) =>
        GetAsync(group, DateTime.Today.AddDays(1), cancellationToken);

    private async Task<Timetable> GetAsync(string group, DateTime date, CancellationToken cancellationToken)
    {
        var parity = ISOWeek.GetWeekOfYear(date) % 2 == 0 ? WeekParity.Even : WeekParity.Odd;
        var entries = await repository.GetAsync(group, date.DayOfWeek, parity, cancellationToken);
        var lessons = entries.Select(entry => new Lesson(
            entry.Subject, entry.Type, entry.Format, entry.Number,
            entry.Building, entry.Auditorium, entry.Lecturer)).ToList();
        return new Timetable(group, parity, lessons);
    }
}
