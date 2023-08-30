using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicCollection.Data;
using MusicCollection.Helpers.Attributes;
using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using MusicCollection.Models.DTOs;
using MusicCollection.Models.Enums;
using MusicCollection.Services.AccountService;

namespace MusicCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MusicCollectionContext _context;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        public AccountsController(MusicCollectionContext context, IMapper mapper, IAccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateAccount(AccountAuthRequestDto account)
        {
            await _accountService.Create(account);
            return Ok();
        }
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(AccountAuthRequestDto account)
        {
            await _accountService.CreateAdmin(account);
            return Ok();
        }

        [HttpPost("login-account")]
        public IActionResult Login(AccountAuthRequestDto account)
        {
            var response = _accountService.Authentificate(account);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }
        //[Authorization(Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<AccountDto>>> GetAccounts()
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            return Ok(await _accountService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccount(Guid id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }

            var accountDto = await _accountService.GetAccountById(id);

            if (accountDto == null)
            {
                return NotFound();
            }
            return Ok(accountDto);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(Guid id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AccountCreateDto>> PostAccount(AccountCreateDto accountDto)
        {
          if (_context.Accounts == null)
          {
              return Problem("Entity set 'MusicCollectionContext.Accounts'  is null.");
          }
       
            var newAccountEntity = await _accountService.AddAccount(accountDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = newAccountEntity.Id }, newAccountEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }

            await _accountService.DeleteAccount(id);

            return NoContent();
        }

        private bool AccountExists(Guid id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
