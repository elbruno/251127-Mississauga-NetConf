#:sdk Aspire.AppHost.Sdk@13.0.1
#:package Aspire.Hosting.JavaScript@13.0.1
#:package Aspire.Hosting.Python@13.0.1

var builder = DistributedApplication.CreateBuilder(args);

var app = builder.AddUvicornApp("app", "./app", "main:app")
    .WithUv()
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health");

var frontend = builder.AddViteApp("frontend", "./frontend")
    .WithReference(app)
    .WaitFor(app);

app.PublishWithContainerFiles(frontend, "./static");

builder.Build().Run();
