using MCServerAPI.Models;

namespace MCServerAPI;

public class ServerPlayers(MinecraftServer server)
{
    private const string Namespace = "minecraft:players";
    
    public async Task<List<Player>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<Player>>(Namespace);
    }

    public async Task<Player?> GetByNameAsync(string name)
    {
        var list = await GetAsync();
        return list.FirstOrDefault(p => p.Name == name);
    }

    public async Task KickAsync(KickPlayer kick)
    {
        await server.rpc.InvokeAsync(Namespace + "/kick", kick);
    }

    public async Task KickAsync(Message msg, params IEnumerable<Player> players)
    {
        await KickAsync(new KickPlayer
        {
            Message = msg,
            Players = players.ToList()
        });
    }
}