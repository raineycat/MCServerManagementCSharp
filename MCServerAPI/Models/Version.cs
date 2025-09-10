namespace MCServerAPI;

public class Version
{
    public required int Protocol { get; set; }
    public required string Name { get; set; }

    public override string ToString()
    {
        return $"Version{{ Name='{Name}', Protocol={Protocol} }}";
    }
}