using MCServerAPI.Models;

namespace MCServerAPI;

public class ServerAllowList(MinecraftServer server)
{
    public async Task<List<Player>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<Player>>("minecraft:allowlist");
    }
    
    public async Task<List<Player>> SetAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<Player>>("minecraft:allowlist/set", players.ToList());
    }
    
    public async Task<List<Player>> AddAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<Player>>("minecraft:allowlist/add", players.ToList());
    }
    
    public async Task<List<Player>> RemoveAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<Player>>("minecraft:allowlist/remove", players.ToList());
    }

    public async Task<List<Player>> ClearAsync()
    {
        return await server.rpc.InvokeAsync<List<Player>>("minecraft:allowlist/clear");
    }
}