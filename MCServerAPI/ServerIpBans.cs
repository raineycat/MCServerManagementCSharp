using MCServerAPI.Models;

namespace MCServerAPI;

public class ServerIpBans(MinecraftServer server)
{
    private const string Namespace = "minecraft:ip_bans";
    
    public async Task<List<IpBan>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<IpBan>>(Namespace);
    }
    
    public async Task<List<IpBan>> SetAsync(params IEnumerable<IpBan> bans)
    {
            return await server.rpc.InvokeAsync<List<IpBan>>(Namespace + "/set", bans.ToList());
    }
    
    public async Task<List<IpBan>> AddAsync(params IEnumerable<IncomingIpBan> bans)
    {
        return await server.rpc.InvokeAsync<List<IpBan>>(Namespace + "/add", bans.ToList());
    }
    
    public async Task<List<IpBan>> RemoveAsync(params IEnumerable<string> ips)
    {
        return await server.rpc.InvokeAsync<List<IpBan>>(Namespace + "/remove", ips.ToList());
    }

    public async Task<List<IpBan>> ClearAsync()
    {
        return await server.rpc.InvokeAsync<List<IpBan>>(Namespace + "/clear");
    }
}