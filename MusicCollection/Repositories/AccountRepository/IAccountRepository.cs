using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;

namespace MusicCollection.Repositories.AccountRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        public Task<List<Account>> GetAccounts();
    }
}
