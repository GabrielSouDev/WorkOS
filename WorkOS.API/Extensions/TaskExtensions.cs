﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Runtime.CompilerServices;
using WorkOS.API.Exceptions;
using WorkOS.API.Hubs;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;
using WorkOS.Shared.DTO.Request;
using WorkOS.Shared.DTO.Response;

namespace WorkOS.API.Extensions;
public static class TaskExtensions
{
    public static void AddTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/Task");

        group.MapGet("/", async ([FromServices] TaskRepository taskRepository) => 
        await taskRepository.GetAllAsync());

        group.MapPut("/", async ([FromServices] TaskRepository taskRepository, [FromBody] TaskItemResponseDTO taskResponseEdited, IHubContext<TaskHub> taskHub) =>
        {
            var task = await taskRepository.FindByIdAsync(taskResponseEdited.Id);
  
            task.AuthorId = taskResponseEdited.AuthorId;
            task.Title = taskResponseEdited.Title;
            task.Description = taskResponseEdited.Description;
            task.Status = taskResponseEdited.Status;
            task.Priority = taskResponseEdited.Priority;

            await taskRepository.UpdateAsync(task);
            await taskHub.Clients.All.SendAsync("UpdateTaskItem", taskResponseEdited);
            return Results.Content("Task has been updated!");
        });


        //CONTINUAR AQUI
        group.MapPost("/", async ([FromServices]DAL<TaskItem> dalTask, [FromBody] TaskItemRequestDTO taskRequest, IHubContext<TaskHub> taskHub) =>
        {
            var task = ToEntity(taskRequest);
            await dalTask.AddAsync(task);

            //task = await dalTask.IncludeAsync<TaskItem, User>(t => t.Author).FindByAsync(t => t.Id == task.Id);

            var taskResponse = ToDTO(task);

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
