using Microsoft.AspNetCore.SignalR;
using WorkOS.Shared.DTO.Response;

namespace WorkOS.API.Hubs;

public class TaskHub : Hub
{
    public async Task Streaming(TaskItemResponseDTO task)
    {
        await Clients.All.SendAsync("UpdateTaskItem", task);
        await Clients.All.SendAsync("NewTaskItem", task);
    }
}
