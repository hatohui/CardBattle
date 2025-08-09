using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class AccountDbContextFactory : IDesignTimeDbContextFactory<AccountDBContext>
{
    public AccountDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AccountDBContext>();
        var connectionString =
            "Host=localhost;Port=5433;Database=accountservice;Username=postgres;Password=postgres123;";
        optionsBuilder.UseNpgsql(connectionString);
        return new AccountDBContext(optionsBuilder.Options);
    }
}
