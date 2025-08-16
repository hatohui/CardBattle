using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AccountRepository : IAccountRepository
{
    private readonly AccountDBContext _context;

    public AccountRepository(AccountDBContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Account account)
    {
        _context.Accounts.Add(account);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account != null)
        {
            _context.Accounts.Remove(account);
            return await _context.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account?> GetByEmailAsync(string email)
    {
        return await _context.Accounts.FirstOrDefaultAsync(account => account.Email.Equals(email));
    }

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        return await _context.Accounts.FirstOrDefaultAsync(account => account.Id == id);
    }

    public async Task<bool> UpdateAsync(Account account)
    {
        _context.Accounts.Update(account);
        return await _context.SaveChangesAsync() > 0;
    }
}
