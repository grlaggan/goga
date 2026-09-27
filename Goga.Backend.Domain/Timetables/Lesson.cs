namespace Goga.Backend.Domain.Timetables;

public enum LessonType
{
    Lecture,
    Practice
}

public enum LessonFormat
{
    Synchronous,
    Asynchronous
}

public sealed class Lesson
{
    private Lesson() { }

    public Lesson(string subject, LessonType type, LessonFormat format, int number,
        string building, string auditorium, string lecturer)
    {
        Subject = subject;
        Type = type;
        Format = format;
        Number = number;
        Building = building;
        Auditorium = auditorium;
        Lecturer = lecturer;
    }

    public string Subject { get; private set; } = null!;
    public LessonType Type { get; private set; }
    public LessonFormat Format { get; private set; }
    public int Number { get; private set; }
    public string Building { get; private set; } = null!;
    public string Auditorium { get; private set; } = null!;
    public string Lecturer { get; private set; } = null!;
}

public static class LessonSchedule
{
    public static TimeSpan GetStartTime(int number)
    {
        return number switch
        {
            1 => new TimeSpan(8, 30, 0),
            2 => new TimeSpan(10, 15, 0),
            3 => new TimeSpan(12, 0, 0),
            4 => new TimeSpan(14, 10, 0),
            5 => new TimeSpan(15, 55, 0),
            6 => new TimeSpan(17, 45, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(number))
        };
    }
}
