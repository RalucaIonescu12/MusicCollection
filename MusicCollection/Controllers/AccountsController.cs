using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Models.Dtos;

namespace MusicCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MusicCollectionContext _context;
        private readonly IMapper _mapper;
        public AccountsController(MusicCollectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            //return await _context.Accounts.ToListAsync();
            return Ok(_mapper.Map<ICollection<AccountDto>>(await _context.Accounts.ToListAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(Guid id)
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
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

            var accountEntity = _mapper.Map<Account>(accountDto); 

            _context.Accounts.Add(accountEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = accountEntity.Id }, accountEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(Guid id)
        {
            return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
