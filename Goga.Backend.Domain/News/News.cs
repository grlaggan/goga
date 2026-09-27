namespace Goga.Backend.Domain.News;

public sealed class News
{
    private News() { }

    public News(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
}
