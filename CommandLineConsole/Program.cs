using MCServerAPI;
using MCServerAPI.Models;

var secret = File.ReadAllText("secret.txt");
using var server = new MinecraftServer("ws://localhost:25585", secret);
await server.ConnectAsync();

Console.WriteLine("Hello, World!");

var status = await server.GetStatusAsync();
Console.WriteLine(status);

await server.SendSystemMessageAsync(new SystemMessage
{
    ReceivingPlayers = status.Players,
    Message = Message.OfTranslatable("block.minecraft.player_head.named", "Player")
});

await server.Players.KickAsync(Message.OfLiteral("waaa"), await server.Players.GetAsync());