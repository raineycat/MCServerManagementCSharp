using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using MCServerAPI.Models;
using Newtonsoft.Json.Serialization;
using StreamJsonRpc;

namespace MCServerAPI;

public class MinecraftServer : IDisposable
{
    private Uri _uri;
    private string _secret;
    private ClientWebSocket _socket;
    internal JsonRpc rpc;

    public ServerOperators Operators { get; }
    public ServerPlayers Players { get; }
    public ServerAllowList AllowList { get; }
    public ServerGameRules GameRules { get; }
    public ServerBans Bans { get; }
    public ServerIpBans IpBans { get; }

    public MinecraftServer(string uri, string secret)
    {
        _uri = new Uri(uri);
        _secret = secret;
        _socket = new ClientWebSocket();
        _socket.Options.SetRequestHeader("Authorization", "Bearer " + secret);

        var formatter = new JsonMessageFormatter();
        formatter.JsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
        
        var handler = new WebSocketMessageHandler(_socket, formatter);
        rpc = new JsonRpc(handler, this);

        #if DEBUG
        rpc.TraceSource = new TraceSource("RpcTracing", SourceLevels.All);
        rpc.TraceSource.Listeners.Add(new ConsoleTraceListener());
        #endif

        Operators = new ServerOperators(this);
        Players = new ServerPlayers(this);
        AllowList = new ServerAllowList(this);
        GameRules = new ServerGameRules(this);
        Bans = new ServerBans(this);
        IpBans = new ServerIpBans(this);
    }

    public async Task ConnectAsync()
    {
        await _socket.ConnectAsync(_uri, CancellationToken.None);
        rpc.StartListening();
    }

    public async Task<ServerStatus> GetStatusAsync()
    {
        return await rpc.InvokeAsync<ServerStatus>("minecraft:server/status");
    }

    public async Task SaveAsync(bool flush)
    {
        await rpc.InvokeAsync("minecraft:server/save", flush);
    }
    
    public async Task StopAsync()
    {
        await rpc.InvokeAsync("minecraft:server/stop");
    }

    public async Task SendSystemMessageAsync(SystemMessage msg)
    {
        await rpc.InvokeAsync("minecraft:server/system_message", msg);
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        rpc.Dispose();
        _socket.Dispose();
    }
}