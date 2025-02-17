using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;
using WorkOS.API.Hubs;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;

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
            var tasksDTO = tasks.Select(t => EntityToDTO(t)).ToList();

            return Results.Ok(tasksDTO);
        });

        group.MapPut("/", async ([FromServices]DAL<TaskItem> dalTask, [FromBody] TaskItemResponseDTO taskRequest, IHubContext<TaskHub> taskHub) =>
        {
            var task = await dalTask.FindByAsync(t=>t.Id == taskRequest.Id);

            if (task is not null)
            {
                task.AuthorId = taskRequest.AuthorId;
                task.Title = taskRequest.Title;
                task.Description = taskRequest.Description;
                task.Status = taskRequest.Status;
                task.Priority = taskRequest.Priority;

                await dalTask.UpdateAsync(task);
                await taskHub.Clients.All.SendAsync("UpdateTaskItem", taskRequest);
                return Results.Content("Task has been updated!");
            }
            return Results.NotFound();
        });
    }
    private static TaskItemResponseDTO EntityToDTO(TaskItem task)
    {
        List<CommentResponseDTO> commentsDto = new();
        foreach (var comment in task.Comments)
        {
            commentsDto.Add(new CommentResponseDTO(comment.Id, comment.Text, comment.TaskId, task.Title, comment.CreationDate));
        }

        return new TaskItemResponseDTO(task.Id, task.Title, task.Description, task.Status,
                    task.Priority, task.AuthorId, task.Author.Name, commentsDto, task.CreationDate);
    }
}
