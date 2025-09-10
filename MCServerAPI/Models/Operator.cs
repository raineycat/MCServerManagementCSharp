namespace MCServerAPI.Models;

public class Operator
{
    public int PermissionLevel { get; set; } = 4;
    public bool BypassesPlayerLimit { get; set; } = true;
    public required Player Player { get; set; }
}