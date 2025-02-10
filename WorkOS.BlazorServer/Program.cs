using MudBlazor.Services;
using WorkOS.BlazorServer.Components;
using WorkOS.BlazorServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

builder.AddServiceDefaults();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5072") });

builder.Services.AddSingleton<ThemeService>();
builder.Services.AddScoped<TaskService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
