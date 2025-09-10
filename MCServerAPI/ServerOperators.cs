using MCServerAPI.Models;

namespace MCServerAPI;

public class ServerOperators(MinecraftServer server)
{
    public async Task<List<Operator>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<Operator>>("minecraft:operators");
    }
    
    public async Task<List<Operator>> SetAsync(params IEnumerable<Operator> ops)
    {
        return await server.rpc.InvokeAsync<List<Operator>>("minecraft:operators/set", ops.ToList());
    }

    public async Task<List<Operator>> SetAsync(params IEnumerable<Player> players)
    {
        return await SetAsync(players.Select(p => new Operator
        {
            Player = p
        }));
    }
    
    public async Task<List<Operator>> AddAsync(params IEnumerable<Operator> ops)
    {
        return await server.rpc.InvokeAsync<List<Operator>>("minecraft:operators/add", ops.ToList());
    }

    public async Task<List<Operator>> AddAsync(params IEnumerable<Player> players)
    {
        return await AddAsync(players.Select(p => new Operator
        {
            Player = p
        }));
    }
    
    public async Task<List<Operator>> RemoveAsync(params IEnumerable<Operator> ops)
    {
        return await server.rpc.InvokeAsync<List<Operator>>("minecraft:operators/remove", ops.ToList());
    }

    public async Task<List<Operator>> RemoveAsync(params IEnumerable<Player> players)
    {
        return await RemoveAsync(players.Select(p => new Operator
        {
            Player = p
        }));
    }

    public async Task<List<Operator>> ClearAsync()
    {
        return await server.rpc.InvokeAsync<List<Operator>>("minecraft:operators/clear");
    }
}