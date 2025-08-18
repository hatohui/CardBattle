using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<Account> CreateAccountAsync(CreateAccountRequest request);
    Task<IEnumerable<Account>> GetAccountsAsync();
    Task<Account?> GetAccountByEmailAsync(string email);
    Task<Account?> GetAccountByIdAsync(Guid id);
    Task<bool> UpdateAccountAsync(Guid id, UpdateAccountRequest request);
    Task<bool> DeleteAccountAsync(Guid id);
}
