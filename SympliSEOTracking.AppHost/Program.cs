var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.SympliSEOTracking_ApiService>("apiservice");

builder.AddProject<Projects.SympliSEOTracking_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
