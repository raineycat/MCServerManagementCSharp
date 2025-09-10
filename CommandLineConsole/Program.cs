using MCServerAPI;

using var server = new MinecraftServer("ws://localhost:25585");
await server.ConnectAsync();

Console.WriteLine("Hello, World!");

var status = await server.GetStatusAsync();
Console.WriteLine(status);