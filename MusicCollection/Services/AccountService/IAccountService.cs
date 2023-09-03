
using DAL.Models;
using DAL.Models.Dtos;
using DAL.Models.DTOs;

namespace MusicCollection.Services.AccountService
{
    public interface IAccountService
    {
        AccountAuthResponseDto Authentificate(AccountAuthRequestDto model);
        public Task<List<AccountDto>> GetAll();
        public Task<Account> AddAccount(AccountCreateDto newAccount);
        //public Task<List<CourseWithStudentsDto>> AddStudentsToCourse(Guid courseId, List<Guid> studentsIds);
        public Task DeleteAccount(Guid accountId);
        public Task<AccountDto> GetAccountById(Guid accountId);
        public Task<Account> GetAccountEntityById(Guid accountId);
        public Task Create(AccountregisterAuthRequestDto newAdmin);
        public Task CreateAdmin(AccountAuthRequestDto newAdmin);
        public Task PutAccount(AccountUpdateDto accountUpdateDto, Guid id);
    }
}
