namespace MCServerAPI.Models;

public class IpBan
{
    public required string Ip { get; set; }
    public string? Reason { get; set; }
    public string? Expires { get; set; }
    public string? Source { get; set; }
}

public class IncomingIpBan : IpBan
{
    public required Player Player { get; set; }
}
