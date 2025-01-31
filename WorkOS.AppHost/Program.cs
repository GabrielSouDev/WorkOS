var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WorkOS_API>("workos-api");

builder.Build().Run();
