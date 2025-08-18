using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddAccountServiceDependencies(
        this WebApplicationBuilder builder,
        string accountDbUrl
    )
    {
        builder.Services.AddDbContext<AccountDBContext>(options => options.UseNpgsql(accountDbUrl));

        builder.Services.AddRepositories();
        builder.Services.AddApplicationServices();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHealthChecks();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Account Service API",
                    Version = "v1",
                    Description = "API for managing accounts in CardBattle",
                }
            );
        });

        return builder;
    }
}
