var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WorkOS_API>("workos-api");

builder.AddProject<Projects.WorkOS_BlazorServer>("workos-blazorserver");

builder.Build().Run();
