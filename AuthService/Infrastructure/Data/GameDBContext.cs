using Microsoft.EntityFrameworkCore;

public class GameDBContext : DbContext
    {
    public GameDBContext(DbContextOptions<GameDBContext> options) : base(options)
    {
    }  
}
