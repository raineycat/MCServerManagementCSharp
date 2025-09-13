namespace ServerManagementSharp.Models;

public class GameRule
{
    public required string Key { get; set; }
    public required string Value { get; set; }
}

public class TypedGameRule : GameRule
{
    public required string Type { get; set; }
}