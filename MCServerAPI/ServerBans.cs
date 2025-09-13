using MCServerAPI.Models;

namespace MCServerAPI;

public class ServerBans(MinecraftServer server)
{
    private const string Namespace = "minecraft:bans";
    
    public async Task<List<UserBan>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<UserBan>>(Namespace);
    }
    
    public async Task<List<UserBan>> SetAsync(params IEnumerable<UserBan> bans)
    {
            return await server.rpc.InvokeAsync<List<UserBan>>(Namespace + "/set", bans.ToList());
    }
    
    public async Task<List<UserBan>> AddAsync(params IEnumerable<UserBan> bans)
    {
        return await server.rpc.InvokeAsync<List<UserBan>>(Namespace + "/add", bans.ToList());
    }
    
    public async Task<List<UserBan>> RemoveAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<UserBan>>(Namespace + "/remove", players.ToList());
    }

    public async Task<List<UserBan>> ClearAsync()
    {
        return await server.rpc.InvokeAsync<List<UserBan>>(Namespace + "/clear");
    }
}