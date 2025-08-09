using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AccountDBContext : DbContext
{
    public AccountDBContext(DbContextOptions<AccountDBContext> options)
        : base(options) { }

    public DbSet<Account> Accounts => Set<Account>();
}
