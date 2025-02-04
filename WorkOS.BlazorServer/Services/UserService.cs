namespace WorkOS.BlazorServer.Services;

public class UserService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> GetUsers()
    {
        var response = await _httpClient.GetAsync("/User");
        return response;
    }
}
