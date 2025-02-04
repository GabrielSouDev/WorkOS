using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;
public static class TaskExtensions
{
    public static void AddTasksEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Task");

        group.MapGet("/", async ([FromServices] DAL<TaskItem> dalGroup) =>
        {

        });
    }
}
