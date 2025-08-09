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

    public async Task<bool> DeleteAsync(int id)
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

    public Task<Account?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Account?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Account account)
    {
        throw new NotImplementedException();
    }
}
