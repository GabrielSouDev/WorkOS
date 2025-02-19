using WorkOS.Shared.DTO.Request;
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
        var response = await _httpClient.GetAsync("/Task");
        if(response.IsSuccessStatusCode)
        {
            var taskList = await response.Content.ReadFromJsonAsync<List<TaskItemResponseDTO>>();
            if (taskList is not null)
                return taskList;
        }  
        return new List<TaskItemResponseDTO>(); 
    }

    public async Task<HttpResponseMessage> PutTaskAsync(TaskItemResponseDTO task)
    {
        HttpResponseMessage response = new();
        try
        {
            response = await _httpClient.PutAsJsonAsync("/Task", task);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return response;
    }

    public async Task<HttpResponseMessage> PostTaskAsync(TaskItemRequestDTO taskRequest)
    {
        HttpResponseMessage response = new();
        try
        {
            response = await _httpClient.PostAsJsonAsync("/Task", taskRequest);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return response;
    }
}
