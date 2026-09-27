namespace Goga.Backend.Domain.Timetables;

public sealed class ScheduleEntry
{
    private ScheduleEntry() { }

    public ScheduleEntry(Guid id, string group, DayOfWeek dayOfWeek, WeekParity weekParity,
        string subject, LessonType type, LessonFormat format, int number,
        string building, string auditorium, string lecturer)
    {
        Id = id;
        Group = group;
        DayOfWeek = dayOfWeek;
        WeekParity = weekParity;
        Subject = subject;
        Type = type;
        Format = format;
        Number = number;
        Building = building;
        Auditorium = auditorium;
        Lecturer = lecturer;
    }

    public Guid Id { get; private set; }
    public string Group { get; private set; } = null!;
    public DayOfWeek DayOfWeek { get; private set; }
    public WeekParity WeekParity { get; private set; }
    public string Subject { get; private set; } = null!;
    public LessonType Type { get; private set; }
    public LessonFormat Format { get; private set; }
    public int Number { get; private set; }
    public string Building { get; private set; } = null!;
    public string Auditorium { get; private set; } = null!;
    public string Lecturer { get; private set; } = null!;
}
