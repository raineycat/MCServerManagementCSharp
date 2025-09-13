namespace MCServerAPI.Models;

public class UserBan
{
    public string? Reason { get; set; }
    public string? Expires { get; set; }
    public string? Source { get; set; }
    public required Player Player { get; set; }
}