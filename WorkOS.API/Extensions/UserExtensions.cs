using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;

public static class UserExtensions
{
    public static void AddUsersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("User");

        //Get All
        group.MapGet("/", async ([FromServices] UserRepository userRepository) =>
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
