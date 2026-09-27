using Goga.Backend.Application.Interfaces;
using Goga.Backend.Domain.Timetables;

namespace Goga.Backend.Application.Timetables;

public sealed class TimetableService : ITimetableService
{
    public Task<Timetable> GetForTodayAsync(string group, CancellationToken cancellationToken)
    {
        var parity = (DateTime.UtcNow.Day / 7) % 2 == 0 ? WeekParity.Even : WeekParity.Odd;
        return Task.FromResult(BuildTimetable(group, parity));
    }

    public Task<Timetable> GetForTomorrowAsync(string group, CancellationToken cancellationToken)
    {
        var parity = ((DateTime.UtcNow.AddDays(1).Day) / 7) % 2 == 0 ? WeekParity.Even : WeekParity.Odd;
        return Task.FromResult(BuildTimetable(group, parity));
    }

    private static Timetable BuildTimetable(string group, WeekParity parity)
    {
        var lessons = new List<Lesson>
        {
            new("Математический анализ", LessonType.Lecture, LessonFormat.Synchronous, 1, "Корпус 1", "ауд. 101", "Иванов И.И."),
            new("Физика", LessonType.Practice, LessonFormat.Synchronous, 2, "Корпус 2", "ауд. 205", "Петров П.П."),
            new("Программирование", LessonType.Lecture, LessonFormat.Synchronous, 3, "Корпус 3", "ауд. 310", "Сидоров С.С."),
            new("Базы данных", LessonType.Practice, LessonFormat.Asynchronous, 4, "Корпус 1", "ауд. 112", "Козлов К.К.")
        };

        return new Timetable(group, parity, lessons);
    }
}
