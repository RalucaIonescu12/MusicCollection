using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MusicCollection.Repositories.AccountRepository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Account>> GetAccounts()
        {
            return await _table.ToListAsync();
        }
    }
}

