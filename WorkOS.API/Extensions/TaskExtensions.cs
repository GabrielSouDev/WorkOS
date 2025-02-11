using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkOS.API.Hubs;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;
using WorkOS.Shared;
using WorkOS.Shared.DTO.Request;
using WorkOS.Shared.DTO.Response;
using static System.Net.Mime.MediaTypeNames;

namespace WorkOS.API.Extensions;
public static class TaskExtensions
{
    public static void AddTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/Task");

        group.MapGet("/", async ([FromServices] DAL<TaskItem> dalTask) =>
        {
            var tasks = await dalTask.ToListAsync();
            List<TaskItemResponseDTO> tasksDTO = new();
            foreach(var task in tasks)
            {
                List<CommentResponseDTO> commentsDto = new();
                foreach(var comment in task.Comments)
                {
                    commentsDto.Add(new CommentResponseDTO(comment.Id, comment.Text, comment.TaskId, task.Title, comment.CreationDate));
                }
                tasksDTO.Add(new TaskItemResponseDTO(task.Id, task.Title, task.Description, task.Status,
                    task.Priority, task.AuthorId, task.Author.Name, commentsDto, task.CreationDate));
            }
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
}
