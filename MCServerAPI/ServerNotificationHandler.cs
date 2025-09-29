using MCServerAPI.Models;
using ServerManagementSharp.Models;
using StreamJsonRpc;

namespace MCServerAPI;

public class ServerNotificationHandler(MinecraftServer server)
{
    private const string Server = "minecraft:notification/server";
    private const string Players = "minecraft:notification/players";
    private const string Operators = "minecraft:notification/operators";
    private const string AllowList = "minecraft:notification/allowlist";
    private const string IpBans = "minecraft:notification/ip_bans";
    private const string Bans = "minecraft:notification/bans";
    private const string GameRules = "minecraft:notification/gamerules";
    
    public event EventHandler? ServerStarted;
    public event EventHandler? ServerStopping;
    public event EventHandler? ServerSaving;
    public event EventHandler? ServerSaved;
    public event EventHandler<ServerStatus>? ServerStatus;

    public event EventHandler<Player>? PlayerJoined;
    public event EventHandler<Player>? PlayerLeft;

    public event EventHandler<Operator>? OperatorAdded; 
    public event EventHandler<Operator>? OperatorRemoved;
    
    public event EventHandler<Player>? AllowListAdded; 
    public event EventHandler<Player>? AllowListRemoved;

    public event EventHandler<IpBan>? IpBanAdded; 
    public event EventHandler<string>? IpBanRemoved;

    public event EventHandler<UserBan>? BanAdded;
    public event EventHandler<Player>? BanRemoved;

    public event EventHandler<TypedGameRule>? GameRuleUpdated; 
    
    [JsonRpcMethod(Server + "/started")]
    private void OnServerStarted() => ServerStarted?.Invoke(server, EventArgs.Empty);

    [JsonRpcMethod(Server + "/stopping")]
    private void OnServerStopping() => ServerStopping?.Invoke(server, EventArgs.Empty);

    [JsonRpcMethod(Server + "/saving")]
    private void OnServerSaving() => ServerSaving?.Invoke(server, EventArgs.Empty);

    [JsonRpcMethod(Server + "/saved")]
    private void OnServerSaved() => ServerSaved?.Invoke(server, EventArgs.Empty);

    [JsonRpcMethod(Server + "/status")]
    private void OnServerStatusHeartbeat(ServerStatus status) => ServerStatus?.Invoke(server, status);

    [JsonRpcMethod(Players + "/joined")]
    private void OnPlayerJoined(Player player) => PlayerJoined?.Invoke(server, player);

    [JsonRpcMethod(Players + "/left")]
    private void OnPlayerLeft(Player player) => PlayerLeft?.Invoke(server, player);

    [JsonRpcMethod(Operators + "/added")]
    private void OnOperatorAdded(Operator op) => OperatorAdded?.Invoke(server, op);
    
    [JsonRpcMethod(Operators + "/removed")]
    private void OnOperatorRemoved(Operator op) => OperatorRemoved?.Invoke(server, op);
    
    [JsonRpcMethod(AllowList + "/added")]
    private void OnAllowListAdded(Player player) => AllowListAdded?.Invoke(server, player);
    
    [JsonRpcMethod(AllowList + "/removed")]
    private void OnAllowListRemoved(Player player) => AllowListRemoved?.Invoke(server, player);

    [JsonRpcMethod(IpBans + "/added")]
    private void OnIpBanAdded(IpBan ban) => IpBanAdded?.Invoke(server, ban); 
    
    [JsonRpcMethod(IpBans + "/removed")]
    private void OnIpBanRemoved(string ip) => IpBanRemoved?.Invoke(server, ip);
    
    [JsonRpcMethod(Bans + "/added")]
    private void OnBanAdded(UserBan ban) => BanAdded?.Invoke(server, ban); 
    
    [JsonRpcMethod(Bans + "/removed")]
    private void OnBanRemoved(Player player) => BanRemoved?.Invoke(server, player);
    
    [JsonRpcMethod(GameRules + "/updated")]
    private void OnGameRuleUpdated(TypedGameRule rule) => GameRuleUpdated?.Invoke(server, rule);
}
