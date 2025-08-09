using Microsoft.EntityFrameworkCore;

public class AccountDbContext    : DbContext
    {
    public AccountDbContext(DbContextOptions<GameDBContext> options) : base(options)
    {
        DbSet<Account> Accounts { get; set; } = null!;
    }  
}
