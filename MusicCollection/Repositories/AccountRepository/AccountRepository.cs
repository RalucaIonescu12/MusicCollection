using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace MusicCollection.Repositories.AccountRepository
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

