using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Account> CreateAccountAsync(CreateAccountRequest request)
    {
        var account = new Account
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
        };

        var newAccount = await _accountRepository.AddAsync(account)
            ? account
            : throw new Exception("Account creation failed");

        return newAccount;
    }

    public async Task<bool> DeleteAccountAsync(int id)
    {
        return await _accountRepository.DeleteAsync(id);
    }

    public async Task<Account?> GetAccountByEmailAsync(string email)
    {
        return await _accountRepository.GetByEmailAsync(email);
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        return await _accountRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
        return await _accountRepository.GetAllAsync();
    }

    public async Task<bool> UpdateAccountAsync(Account account)
    {
        return await _accountRepository.UpdateAsync(account);
    }
}
