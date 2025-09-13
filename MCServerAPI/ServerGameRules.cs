using ServerManagementSharp.Models;

namespace MCServerAPI;

public class ServerGameRules(MinecraftServer server)
{
    private const string Namespace = "minecraft:gamerules";
    
    public async Task<List<TypedGameRule>> GetAsync()
    {
        return await server.rpc.InvokeAsync<List<TypedGameRule>>(Namespace);
    }

    public async Task<string?> GetAsync(string key)
    {
        var rules = await GetAsync();
        return rules.FirstOrDefault(r => r.Key == key)?.Value;
    }

    public async Task<TypedGameRule> UpdateAsync(GameRule rule)
    {
        return await server.rpc.InvokeAsync<TypedGameRule>(Namespace + "/update", rule);
    }

    public async Task<TypedGameRule> UpdateAsync(string key, string value)
    {
        return await UpdateAsync(new GameRule
        {
            Key = key,
            Value = value
        });
    }
}