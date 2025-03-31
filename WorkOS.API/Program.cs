using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WorkOS.API.Exceptions;
using WorkOS.API.Extensions;
using WorkOS.API.Hubs;
using WorkOS.Data.Context;
using WorkOS.Data.DAL;
using WorkOS.Data.Entitys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("MemoryDB")
           .UseLazyLoadingProxies();
    //.UseSqlServer(builder.Configuration
    //                     .GetConnectionString("DefaultConnection"))
    //                     .UseLazyLoadingProxies();
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.SerializerOptions.PropertyNamingPolicy = null;
    // Permite enum serem serializados/deserializados como strings
    //options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWorkOSClient", builder =>
    {
        builder.WithOrigins("https://localhost:7186", "http://localhost:5013")
                         .AllowAnyMethod()
                         .AllowAnyHeader();
    });
});

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<CompanyRepository>();
builder.Services.AddTransient<GroupRepository>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<TaskRepository>();
builder.Services.AddTransient<CommentRepository>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
    //dbContext.CreateTable().Wait();
}

app.MapHub<TaskHub>("/TaskHub");

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowWorkOSClient");

app.AddCompanysEndpoints();
app.AddGroupsEndpoints();
app.AddUsersEndpoints();
app.AddTasksEndpoints();
app.AddCommentEndpoints();

app.Run();