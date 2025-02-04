using Microsoft.AspNetCore.Mvc;
using WorkOS.Data.Context;
using WorkOS.Data.Entitys;

namespace WorkOS.API.Extensions;
public static class CompanyExtensions
{
    public static void AddCompanysEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("Company");

        group.MapGet("/", async ([FromServices] DAL<Company> dalGroup) =>
        {

        });
    }
}
