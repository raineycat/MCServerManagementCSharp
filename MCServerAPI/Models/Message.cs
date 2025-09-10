namespace MCServerAPI.Models;

public abstract class Message
{
    public static Message OfLiteral(string content) => new LiteralMessage
    {
        Literal = content
    };

    public static Message OfTranslatable(string key, params string[] args) => new TranslatableMessage
    {
        Translatable = key,
        TranslatableParams = args.ToList()
    };
}

public class LiteralMessage : Message
{
    public required string Literal { get; set; }
}

public class TranslatableMessage : Message
{
    public required string Translatable { get; set; }
    public List<string> TranslatableParams { get; set; } = [];
}