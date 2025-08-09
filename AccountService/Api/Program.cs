using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using DotNetEnv;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

//* Load .env file if present */
Env.Load();
var builder = WebApplication.CreateBuilder(args);

//* Get the connection string from the environment variable */
var accountDbUrl =
    Environment.GetEnvironmentVariable("ACCOUNT_DB_URL")
    ?? throw new InvalidOperationException("ACCOUNT_DB_URL environment variable is not set.");

//* Register the database context */
builder.Services.AddDbContext<AccountDBContext>(options => options.UseNpgsql(accountDbUrl));

//* Register repositories */
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

//* Register services */
builder.Services.AddControllers();
builder.Services.AddOpenApi();

//* Configure the OpenAPI documentation */
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//* Configure the HTTP request pipeline */
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
