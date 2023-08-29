using AutoMapper;
using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using MusicCollection.Repositories.AccountRepository;

namespace MusicCollection.Services.AccountService
{
    public class AccountService : IAccountService
    {
        public IAccountRepository _accountRepository;
        public IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task AddAccount(AccountDto newAccount)
        {
            // var newDbAccount = new Account();
            var newAccountEntity = _mapper.Map<Account>(newAccount);
            await _accountRepository.CreateAsync(newAccountEntity);
            await _accountRepository.SaveAsync();
        }

        //public async Task<List<AccountWithStudentsDto>> AddStudentsToAccount(Guid accountId, List<Guid> studentsIds)
        //{
        //    var accountToUpdate = await _accountRepository.FindByIdAsync(accountId);
        //    List<Student> studentsFromDbList = await _studentRepository.FindRange(studentsIds);
            
        //    List<StudentInAccount> studentInAccountList = new();

        //    foreach (var student in studentsFromDbList)
        //    {
        //        var newStudentInAccount = new StudentInAccount
        //        {
        //            Student = student,
        //            Account = accountToUpdate
        //        };

        //        studentInAccountList.Add(newStudentInAccount);
        //    }
        //    await _studentInAccountRepository.CreateRangeAsync(studentInAccountList);
        //    await _studentInAccountRepository.SaveAsync();

        //    var accountsWithStudents = await _accountRepository.GetAccountsWithStudents();
        //    return _mapper.Map<List<AccountWithStudentsDto>> (accountsWithStudents);
        //}

        public async Task DeleteAccount(Guid accountId)
        {
            var accountToDelete = await _accountRepository.FindByIdAsync(accountId);
            _accountRepository.Delete(accountToDelete);
            await _accountRepository.SaveAsync();
        }

        public async Task<List<AccountDto>> GetAll()
        {
            var accounts = await _accountRepository.GetAll();
            return _mapper.Map< List<AccountDto>>(accounts);
        }
    }
}
