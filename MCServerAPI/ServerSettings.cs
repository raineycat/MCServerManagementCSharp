namespace MCServerAPI;

public class ServerSettings(MinecraftServer server)
{
    public readonly AsyncSetting<bool> Autosave = new(server, "autosave");
    public readonly AsyncSetting<string> Difficulty = new(server, "difficulty");
    public readonly AsyncSetting<bool> EnforceAllowList = new(server, "enforce_allowlist");
    public readonly AsyncSetting<bool> UseAllowList = new(server, "use_allowlist");
    public readonly AsyncSetting<int> MaxPlayers = new(server, "max_players");
    public readonly AsyncSetting<int> PauseWhenEmptySeconds = new(server, "pause_when_empty_seconds");
    public readonly AsyncSetting<int> PlayerIdleTimeout = new(server, "player_idle_timeout");
    public readonly AsyncSetting<bool> AllowFlight = new(server, "allow_flight");
    public readonly AsyncSetting<string> Motd = new(server, "motd");
    public readonly AsyncSetting<int> SpawnProtectionRadius = new(server, "spawn_protection_radius");
    public readonly AsyncSetting<bool> ForceGameMode = new(server, "force_game_mode");
    public readonly AsyncSetting<string> DefaultGameMode = new(server, "game_mode");
    public readonly AsyncSetting<int> ViewDistance = new(server, "view_distance");
    public readonly AsyncSetting<int> SimulationDistance = new(server, "simulation_distance");
    public readonly AsyncSetting<bool> AcceptTransfers = new(server, "accept_transfers");
    public readonly AsyncSetting<int> StatusHeartbeatInterval = new(server, "status_heartbeat_interval");
    public readonly AsyncSetting<int> OperatorUserPermissionLevel = new(server, "operator_user_permission_level");
    public readonly AsyncSetting<bool> HideOnlinePlayers = new(server, "hide_online_players");
    public readonly AsyncSetting<bool> StatusReplies = new(server, "status_replies");
    public readonly AsyncSetting<int> EntityBroadcastRange = new(server, "entity_broadcast_range");
}