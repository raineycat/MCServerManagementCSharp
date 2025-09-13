namespace MCServerAPI;

public class AsyncSetting<T>(MinecraftServer server, string name)
{
    private const string Namespace = "minecraft:serversettings";
    
    public async Task<T> GetAsync()
    {
        return await server.rpc.InvokeAsync<T>($"{Namespace}/{name}");
    }

    public async Task<T> SetAsync(T value)
    {
        return await server.rpc.InvokeAsync<T>($"{Namespace}/{name}/set", value);
    }
}