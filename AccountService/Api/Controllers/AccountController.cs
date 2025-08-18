using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest request)
    {
        try
        {
            await _accountService.CreateAccountAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts()
    {
        var accounts = await _accountService.GetAccountsAsync();

        if (!accounts.Any())
            return NotFound(new { Message = "No accounts found." });

        return Ok(accounts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(Guid id)
    {
        var account = await _accountService.GetAccountByIdAsync(id);

        if (account == null)
        {
            return NotFound(new { Message = "Account not found." });
        }

        return Ok(account);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        var result = await _accountService.DeleteAccountAsync(id);

        if (!result)
        {
            return NotFound(new { Message = "Account not found." });
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] UpdateAccountRequest request)
    {
        var result = await _accountService.UpdateAccountAsync(id, request);

        if (!result)
        {
            return BadRequest(new { Message = "Account update failed." });
        }

        return NoContent();
    }
}
