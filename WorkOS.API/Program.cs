using Microsoft.EntityFrameworkCore;
using WorkOS.API.Extensions;
using WorkOS.Shared.Data;
using WorkOS.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies()
           .UseSqlServer(builder.Configuration
                                .GetConnectionString("DefaultConnection"));
});

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DAL<Group>>();
builder.Services.AddTransient<DAL<User>>();
builder.Services.AddTransient<DAL<TaskItem>>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.CreateTable().Wait();
}

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddGroupsEndpoints();
app.AddUsersEndpoints();
app.AddTasksEndpoints();

app.Run();