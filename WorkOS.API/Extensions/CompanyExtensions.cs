using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;
public static class CompanyExtensions
{
    public static void AddCompanysEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Company");

        group.MapGet("/", async ([FromServices] CompanyRepository companyRepository) =>
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
