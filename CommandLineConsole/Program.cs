using MCServerAPI;

var secret = File.ReadAllText("secret.txt");
using var server = new MinecraftServer("ws://localhost:25585", secret);
await server.ConnectAsync();

Console.WriteLine("Hello, World!");

var status = await server.GetStatusAsync();
Console.WriteLine(status);

await server.Settings.Motd.SetAsync("meoww!!!");

var completionSource = new TaskCompletionSource();

server.Notifications.ServerStopping += (_, _) =>
{
    Console.WriteLine("Server stopping!");
    completionSource.SetResult();
};

server.Notifications.PlayerJoined += (_, player) =>
{
    Console.WriteLine($"Player '{player.Name}' ({player.Id}) just joined!");
};

await completionSource.Task;
Console.WriteLine("Exiting...");