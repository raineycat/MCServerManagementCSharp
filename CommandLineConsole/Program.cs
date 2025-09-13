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

var keepInv = await server.GameRules.GetAsync("keepInventory");
//if (keepInv is null or "false")
if (keepInv == null || keepInv == "false")
{
    Console.WriteLine("Enabling keep inventory!");
    await server.GameRules.UpdateAsync("keepInventory", "true");
}

await server.Bans.AddAsync(new UserBan
{
    Player = await server.Players.GetByNameAsync("reddust9"),
    Reason = "because meow",
});