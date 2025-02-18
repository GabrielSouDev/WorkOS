using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;
public static class CommentExtensions
{
    public static void AddCommentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Comment");

        group.MapGet("/", async ([FromServices]DAL<Comment> dalComment) =>
        {
            throw new NotImplementedException();
        });
    }
}
