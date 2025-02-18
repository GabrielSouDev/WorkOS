using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;

public static class UserExtensions
{
    public static void AddUsersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("User");

        group.MapGet("/", async ([FromServices] DAL<User> dalGroup) =>
        {
            throw new NotImplementedException();
        });
    }
}
