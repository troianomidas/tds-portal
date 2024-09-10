namespace WebApp.Services;

public interface IPublicIpService
{
    Task<string> GetAsync();
}

public class IpiFyService : IPublicIpService
{
    private readonly IHttpClientFactory _clientFactory;
    
    public IpiFyService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<string> GetAsync()
    {
        HttpClient client = _clientFactory.CreateClient();
        try
        {
            return await client.GetStringAsync("https://api.ipify.org/?format=text");
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e.Message);
            return "";
        }
    }
}