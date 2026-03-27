var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var postgresDb = postgres.AddDatabase("Database");


var api = builder.AddProject<Projects.Clean_WebAPI>("api")
    .WithReference(postgresDb)
    .WaitFor(postgresDb);

builder.Build().Run();