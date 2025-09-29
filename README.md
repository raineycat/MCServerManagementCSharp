# MCServerManagementCSharp

This is a client for the new [server management protocol](https://minecraft.wiki/w/Minecraft_Server_Management_Protocol) in C#.

Most methods here are `async`, due to the underlying JSON-RPC being asyncronous.

### Connecting:
```cs
﻿using MCServerAPI;

using var server = new MinecraftServer("ws://localhost:25585", secret);
await server.ConnectAsync();
Console.WriteLine("Connected to the server!");
```

### Simple queries:
```cs
var status = await server.GetStatusAsync();
Console.WriteLine(status);

var players = await server.Players.GetAsync();
var jeb = await server.Players.GetByNameAsync("jeb_");
```

### Server settings:
```cs
var oldMotd = await server.Settings.Motd.GetAsync();
await server.Settings.Motd.SetAsync(oldMotd + " - updated!");

await server.Settings.Difficulty.SetAsync("hard");
```

### Notifications:
```cs
server.Notifications.ServerStopping += (_, _) =>
{
    Console.WriteLine("Server stopping!");
    Environment.Exit(0);
};

server.Notifications.PlayerJoined += (_, player) => Console.WriteLine($"Player '{player.Name}' ({player.Id}) just joined!");

server.Notifications.GameRuleUpdated += (_, rule) => Console.WriteLine($"Gamerule '{rule.Key}' was set to: {rule.Value}");
```
