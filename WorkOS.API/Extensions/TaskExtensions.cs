using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;
using WorkOS.API.Exceptions;
using WorkOS.API.Hubs;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;
using WorkOS.Shared.DTO.Request;
using WorkOS.Shared.DTO.Response;

namespace WorkOS.API.Extensions;
public static class TaskExtensions
{
    public static void AddTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/Task");

        group.MapGet("/", async ([FromServices] DAL<TaskItem> dalTask) =>
        {
            var tasks = await dalTask.ToListAsync();
            if(tasks is null)
                throw new TaskItemNotFoundException();

            var tasksDTO = tasks.Select(t => ToDTO(t)).ToList();
            return Results.Ok(tasksDTO);
        });

        group.MapPut("/", async ([FromServices]DAL<TaskItem> dalTask, [FromBody] TaskItemResponseDTO taskRequest, IHubContext<TaskHub> taskHub) =>
        {
            var task = await dalTask.FindByAsync(t=>t.Id == taskRequest.Id);

            if (task is null)
                throw new TaskItemNotFoundException();
  
            task.AuthorId = taskRequest.AuthorId;
            task.Title = taskRequest.Title;
            task.Description = taskRequest.Description;
            task.Status = taskRequest.Status;
            task.Priority = taskRequest.Priority;

            await dalTask.UpdateAsync(task);
            await taskHub.Clients.All.SendAsync("UpdateTaskItem", taskRequest);
            return Results.Content("Task has been updated!");
        });

        group.MapPost("/", async ([FromServices]DAL<TaskItem> dalTask, [FromBody] TaskItemRequestDTO taskRequest, IHubContext<TaskHub> taskHub) =>
        {
            var task = ToEntity(taskRequest);
            await dalTask.AddAsync(task);

            var taskEntity = dalTask.FindByAsync(t => t.Id == task.Id).GetAwaiter().GetResult() ;

            var taskResponse = ToDTO(taskEntity);

            await taskHub.Clients.All.SendAsync("NewTaskItem", taskResponse);

            return Results.NoContent();
        });
    }
    
    private static TaskItemResponseDTO ToDTO(TaskItem task)
    {
        List<CommentResponseDTO> commentsDto = new();

        foreach (var comment in task.Comments)
        {
            commentsDto.Add(new CommentResponseDTO(comment.Id, comment.Text, comment.TaskId, task.Title, comment.CreationDate));
        }

        return new TaskItemResponseDTO(task.Id, task.Title, task.Description, task.Status,
                    task.Priority, task.AuthorId, task.Author.Name, commentsDto, task.CreationDate);
    }

    private static TaskItem ToEntity(TaskItemRequestDTO taskRequest) => 
        new TaskItem(taskRequest.AuthorId, taskRequest.Title, taskRequest.Description, taskRequest.Priority);
}
