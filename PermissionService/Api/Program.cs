using Api.Grpc;
using Application.Interfaces;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPermissionService, Application.Services.PermissionService>();

builder.Services.AddGrpc();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseRouting();
app.MapGrpcService<PermissionGrpcService>();
app.MapHealthChecks("/healthz");

app.Run();
