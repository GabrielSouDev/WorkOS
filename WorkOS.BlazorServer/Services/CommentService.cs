using WorkOS.Shared.DTO.Request;
using WorkOS.Shared.DTO.Response;

namespace WorkOS.BlazorServer.Services;

public class CommentService
{
    private readonly HttpClient _httpClient;
    public CommentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> PutCommentAsync(CommentResponseDTO comment)
    {
        HttpResponseMessage response = new();
        try
        {
            response = await _httpClient.PutAsJsonAsync("/Comment", comment);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return response;
    }

    public async Task<HttpResponseMessage> PostCommentAsync(CommentRequestDTO commentRequest)
    {
        HttpResponseMessage response = new();
        try
        {
            response = await _httpClient.PostAsJsonAsync("/Comment", commentRequest);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return response;
    }
}
