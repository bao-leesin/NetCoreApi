using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetAccount(string username)
        {
            var account = await _accountService.GetAccountByUsernameAsync(username);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] ACCOUNT account)
        {
            await _accountService.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { username = account.USERNAME }, account);
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateAccount(string username, [FromBody] ACCOUNT account)
        {
            if (username != account.USERNAME)
            {
                return BadRequest();
            }

            await _accountService.UpdateAccountAsync(account);
            return NoContent();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteAccount(string username)
        {
            await _accountService.DeleteAccountAsync(username);
            return NoContent();
        }
    }
}
