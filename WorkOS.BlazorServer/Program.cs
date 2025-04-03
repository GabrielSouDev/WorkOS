using MudBlazor.Services;
using WorkOS.BlazorServer.Components;
using WorkOS.BlazorServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();

builder.AddServiceDefaults();

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri("http://localhost:5072") });

builder.Services.AddSingleton<ThemeService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<CommentService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
