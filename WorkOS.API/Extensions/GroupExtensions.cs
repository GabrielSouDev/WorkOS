﻿using Microsoft.AspNetCore.Mvc;
using WorkOS.Shared.Data;
using WorkOS.Shared.Models;

namespace WorkOS.API.Extensions;
public static class GroupExtensions
{
    public static void AddGroupsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Group");

        group.MapGet("/", async ([FromServices]DAL<Group> dalGroup) =>
        {
            var groups = await dalGroup.ToListAsync();
            if(groups is not null)
            {
                return Results.Ok(groups);
            }
            return Results.NotFound();
        });

        group.MapGet("/{id}", async ([FromServices] DAL<Group> dalGroup, [FromBody] int id) =>
        {
            var group = await dalGroup.FindByAsync(g => g.Id.Equals(id));
            if (group is not null)
            {
                return Results.Ok(group);
            }
            return Results.NotFound();
        });
    }
}
