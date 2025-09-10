namespace MCServerAPI;

public class Player
{
    public required string Name { get; set; }
    public required Guid Id { get; set; }

    public override string ToString()
    {
        return $"Player{{ Name='{Name}', ID={Id} }}";
    }
}