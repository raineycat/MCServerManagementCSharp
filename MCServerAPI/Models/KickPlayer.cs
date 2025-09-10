namespace MCServerAPI.Models;

public class KickPlayer
{
    public List<Player> Players { get; set; } = [];
    public required Message Message { get; set; }
}