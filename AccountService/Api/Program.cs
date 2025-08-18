using Api.Extensions;
using DotNetEnv;

Env.Load();

//Env config
var accountDbUrl =
    Environment.GetEnvironmentVariable("ACCOUNT_DB_URL")
    ?? throw new InvalidOperationException("ACCOUNT_DB_URL environment variable is not set.");

// Create the web application builder
var builder = WebApplication.CreateBuilder(args);
builder.AddAccountServiceDependencies(accountDbUrl);

// Build the application
var app = builder.Build();
app.UseAccountServicePipeline();

// Run the application
app.Run();
