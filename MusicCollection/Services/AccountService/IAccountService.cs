
using MusicCollection.Models;
using MusicCollection.Models.Dtos;

namespace MusicCollection.Services.AccountService
{
    public interface IAccountService
    {
        public Task<List<AccountDto>> GetAll();
        public Task AddAccount(AccountDto newAccount);
        //public Task<List<CourseWithStudentsDto>> AddStudentsToCourse(Guid courseId, List<Guid> studentsIds);
        public Task DeleteAccount(Guid accountId);
    }
}
