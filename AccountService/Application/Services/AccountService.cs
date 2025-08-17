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
        var existingAccount = await _accountRepository.GetByEmailAsync(request.Email);

        if (existingAccount != null)
        {
            throw new Exception("Account with this email already exists");
        }

        var account = new Account
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            PasswordHash = request.Password,
        };

        var newAccount = await _accountRepository.AddAsync(account)
            ? account
            : throw new Exception("Account creation failed");

        return newAccount;
    }

    public async Task<bool> DeleteAccountAsync(Guid id)
    {
        return await _accountRepository.DeleteAsync(id);
    }

    public async Task<Account?> GetAccountByEmailAsync(string email)
    {
        return await _accountRepository.GetByEmailAsync(email);
    }

    public async Task<Account?> GetAccountByIdAsync(Guid id)
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
