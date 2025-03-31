using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;
public static class GroupExtensions
{
    public static void AddGroupsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Group");

        group.MapGet("/", async ([FromServices] GroupRepository groupRepository) =>
        {
            throw new NotImplementedException();
        });

        //Get By Id
        group.MapGet("/{id}", async (int id) =>
        {
            throw new NotImplementedException();
        });

        //Post
        group.MapPost("/", async () =>
        {
            throw new NotImplementedException();
        });

        //Put
        group.MapPut("/", async () =>
        {
            throw new NotImplementedException();
        });

        //Delete
        group.MapDelete("/{id}", async (int id) =>
        {
            throw new NotImplementedException();
        });
    }
}
