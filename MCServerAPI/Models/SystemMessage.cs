namespace MCServerAPI.Models;

public class SystemMessage
{
    public List<Player> ReceivingPlayers { get; set; } = [];
    public bool Overlay { get; set; }
    public required Message Message { get; set; }
}