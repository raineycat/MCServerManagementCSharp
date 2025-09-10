using System.Net.WebSockets;
using StreamJsonRpc;

namespace MCServerAPI;

public class MinecraftServer : IDisposable
{
    private Uri _uri;
    private ClientWebSocket _socket;
    private JsonRpc _rpc;

    public MinecraftServer(string uri)
    {
        _uri = new Uri(uri);
        _socket = new ClientWebSocket();
        
        var handler = new WebSocketMessageHandler(_socket);
        _rpc = new JsonRpc(handler, this);
    }

    public async Task ConnectAsync()
    {
        await _socket.ConnectAsync(_uri, CancellationToken.None);
        _rpc.StartListening();
    }

    public async Task<ServerStatus> GetStatusAsync()
    {
        return await _rpc.InvokeAsync<ServerStatus>("minecraft:server/status");
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _rpc.Dispose();
        _socket.Dispose();
    }
}