namespace Goga.Backend.Domain.Sports;

public sealed class SportSection
{
    private SportSection() { }

    public SportSection(string name, string description, string location)
    {
        Name = name;
        Description = description;
        Location = location;
    }

    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Location { get; private set; } = null!;
}
