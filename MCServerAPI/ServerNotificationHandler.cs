using MCServerAPI.Models;
using StreamJsonRpc;

namespace MCServerAPI;

public class ServerNotificationHandler(MinecraftServer server)
{
    private const string Server = "notification:server";
    private const string Players = "notification:players";
    
    public event EventHandler? ServerStarted;
    public event EventHandler? ServerStopping;
    public event EventHandler? ServerSaving;
    public event EventHandler? ServerSaved;
    public event EventHandler<ServerStatus>? ServerStatus;

    public event EventHandler<Player>? PlayerJoined;
    public event EventHandler<Player>? PlayerLeft;
    
    [JsonRpcMethod(Server + "/started")]
    private void OnServerStarted()
    {
        ServerStarted?.Invoke(server, EventArgs.Empty);
    }
    
    [JsonRpcMethod(Server + "/stopping")]
    private void OnServerStopping()
    {
        ServerStopping?.Invoke(server, EventArgs.Empty);
    }
    
    [JsonRpcMethod(Server + "/saving")]
    private void OnServerSaving()
    {
        ServerSaving?.Invoke(server, EventArgs.Empty);
    }
    
    [JsonRpcMethod(Server + "/saved")]
    private void OnServerSaved()
    {
        ServerSaved?.Invoke(server, EventArgs.Empty);
    }
    
    [JsonRpcMethod(Server + "/status")]
    private void OnServerStatusHeartbeat(ServerStatus status)
    {
        ServerStatus?.Invoke(server, status);
    }

    [JsonRpcMethod(Players + "/joined")]
    public void OnPlayerJoined(Player player)
    {
        PlayerJoined?.Invoke(server, player);
    }
    
    [JsonRpcMethod(Players + "/left")]
    public void OnPlayerLeft(Player player)
    {
        PlayerLeft?.Invoke(server, player);
    }
}