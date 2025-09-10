namespace MCServerAPI.Models;

public class ServerStatus
{
    public List<Player> Players { get; set; } = [];
    public required bool Started { get; set; }
    public required Version Version { get; set; }

    public override string ToString()
    {
        return $"ServerStatus{{ Version={Version} Started={Started} Players=[{string.Join(',', Players)}] }}";
    }
}