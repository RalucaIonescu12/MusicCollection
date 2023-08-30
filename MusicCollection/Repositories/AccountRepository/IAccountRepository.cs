using MusicCollection.Models;
using MusicCollection.Models.DTOs;
using MusicCollection.Repository.GenericRepository;
using NuGet.DependencyResolver;

namespace MusicCollection.Repositories.AccountRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    
        public Task<List<Account>> GetAccounts();
        public Task<Account> GetAccountById(Guid accountId);
        Account FindByEmail(string email);
    }
}
