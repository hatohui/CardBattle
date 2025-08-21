using Api.Grpc;
using Api.Middlewares;
using Application.Interfaces;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Replace console logging formatter so the console output does not include the category/event id prefix
builder.Services.AddLogging();

//set up services
builder.Services.AddScoped<IPermissionService, Application.Services.PermissionService>();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddHealthChecks();

// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseRouting();
app.UseMiddleware<LogMiddleware>();
app.MapGrpcService<PermissionGrpcService>();
app.MapHealthChecks("/healthz");

app.Run();
