namespace Goga.Backend.Domain.Timetables;

public enum WeekParity
{
    Even,
    Odd
}

public sealed class Timetable
{
    private Timetable() { }

    public Timetable(string group, WeekParity weekParity, IReadOnlyList<Lesson> lessons)
    {
        Group = group;
        WeekParity = weekParity;
        Lessons = lessons;
    }

    public string Group { get; private set; } = null!;
    public WeekParity WeekParity { get; private set; }
    public IReadOnlyList<Lesson> Lessons { get; private set; } = Array.Empty<Lesson>();
}
