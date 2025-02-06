using System.Text.Json;
using WorkOS.Shared;
using WorkOS.Shared.DTO.Response;

namespace WorkOS.BlazorServer.Services;

public class TaskService
{
    private readonly HttpClient _httpClient;
    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TaskItemResponseDTO>> GetTasksAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<TaskItemResponseDTO>>("/Task");
        Console.WriteLine(response);

        if (response != null)
        {
            return response;
        }
        else
            return response;
    }
}
