using MCServerAPI.Models;

namespace MCServerAPI;

public class ServerAllowList(MinecraftServer server)
{
    private const string Namespace = "minecraft:allowlist";
    
    public async Task<List<Player>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<Player>>(Namespace);
    }
    
    public async Task<List<Player>> SetAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<Player>>(Namespace + "/set", players.ToList());
    }
    
    public async Task<List<Player>> AddAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<Player>>(Namespace + "/add", players.ToList());
    }
    
    public async Task<List<Player>> RemoveAsync(params IEnumerable<Player> players)
    {
        return await server.rpc.InvokeAsync<List<Player>>(Namespace + "/remove", players.ToList());
    }

    public async Task<List<Player>> ClearAsync()
    {
        return await server.rpc.InvokeAsync<List<Player>>(Namespace + "/clear");
    }
}