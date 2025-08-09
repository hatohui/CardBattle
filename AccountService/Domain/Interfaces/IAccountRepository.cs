using Domain.Entities;

namespace Domain.Interfaces;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(int id);
    Task<Account?> GetByEmailAsync(string email);
    Task<IEnumerable<Account>> GetAllAsync();
    Task<bool> AddAsync(Account account);
    Task<bool> UpdateAsync(Account account);
    Task<bool> DeleteAsync(int id);
}
