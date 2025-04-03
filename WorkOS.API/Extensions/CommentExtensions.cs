using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;
using WorkOS.Data.Exceptions;
using WorkOS.Shared.DTO.Request;
using WorkOS.Shared.DTO.Response;

namespace WorkOS.API.Extensions;
public static class CommentExtensions
{
    public static void AddCommentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Comment");

        //Post   VERIFICAR EM TODOS POSTS SE JÁ EXISTE ANTES DE ADICIONAR
        group.MapPost("/", async ([FromServices] CommentRepository commentRepository, [FromBody] CommentRequestDTO commentRequest) =>
        {
            var comment = ToEntity(commentRequest);
            await commentRepository.AddAsync(comment);

            return Results.NoContent();
        });

        //Put
        group.MapPut("/", async ([FromServices] CommentRepository commentRepository, [FromBody] CommentResponseDTO commentResponse) =>
        {
            Console.WriteLine($"Id: {commentResponse.Id}\nComment: {commentResponse.Text}");
            var commentEntity = await commentRepository.FindByIdAsync(commentResponse.Id);
            if (commentEntity is null)
                throw new EntityNotFoundException();

            commentEntity.Text = commentResponse.Text;
            await commentRepository.UpdateAsync(commentEntity);

            return Results.NoContent();
        });

        //Delete
        group.MapDelete("/{id}", async (int id, [FromServices] CommentRepository commentRepository) =>
        {
            await commentRepository.DeleteByIdAsync(id);
            return Results.NoContent();
        });
    }

    private static Comment ToEntity(CommentRequestDTO commentRequest) => 
        new Comment(commentRequest.TaskId, commentRequest.Text);
}
