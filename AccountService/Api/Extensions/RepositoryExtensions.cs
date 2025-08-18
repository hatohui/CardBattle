using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Api.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }
}
