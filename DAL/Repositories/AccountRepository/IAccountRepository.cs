using DAL.Models;
using DAL.Models.DTOs;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories.AccountRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    
        public Task<List<Account>> GetAccounts();
        public Task<Account> GetAccountById(Guid accountId);
        Account FindByEmail(string email);
    }
}
