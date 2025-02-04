using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WorkOS.API.Extensions;
using WorkOS.Shared.Data;
using WorkOS.Shared.Entitys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies()
           .UseSqlServer(builder.Configuration
                                .GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    // Preserva as referências, evitando erros de ciclo de referência
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

    // Define que propriedades nulas sejam incluídas no JSON
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

    // Mantém a nomeação das propriedades como está no modelo, sem aplicar camelCase
    options.SerializerOptions.PropertyNamingPolicy = null;

    // Permite enum serem serializados/deserializados como strings
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
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

app.UseCors("AllowWorkOSClient");

app.AddGroupsEndpoints();
app.AddUsersEndpoints();
app.AddTasksEndpoints();

app.Run();