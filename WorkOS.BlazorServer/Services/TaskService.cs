using System.Text.Json;
using WorkOS.Shared;
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
        try
        {
            var response = await _httpClient.GetAsync("/Task");
            if(response.IsSuccessStatusCode)
            {
                var taskList = await response.Content.ReadFromJsonAsync<List<TaskItemResponseDTO>>();
                if(taskList is not null)
                    return taskList;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }    
        return new List<TaskItemResponseDTO>(); 
    }

    public async Task<HttpResponseMessage> PutTaskAsync(TaskItemResponseDTO task)
    {
        HttpResponseMessage response = new();
        try
        {
            response = await _httpClient.PutAsJsonAsync("/Task", task);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return response;
    }
}
