using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;
public static class GroupExtensions
{
    public static void AddGroupsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Group");

        group.MapGet("/", async ([FromServices]DAL<Group> dalGroup) =>
        {
            throw new NotImplementedException();
            var groups = await dalGroup.ToListAsync();
            if(groups is not null)
            {
                return Results.Ok(groups);
            }
            return Results.NotFound();
        });

        group.MapGet("/{id}", async ([FromServices] DAL<Group> dalGroup, int id) =>
        {
            throw new NotImplementedException();
            var group = await dalGroup.FindByAsync(g => g.Id.Equals(id));
            if (group is not null)
            {
                return Results.Ok(group);
            }
            return Results.NotFound();
        });
    }
}
