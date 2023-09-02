using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.AccountRepository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Account>> GetAccounts()
        {
            return await _table.ToListAsync();
        }

        public async Task<Account> GetAccountById(Guid accountId)
        {
            return await FindByIdAsync(accountId);
        }
        public Account FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
    }
}

