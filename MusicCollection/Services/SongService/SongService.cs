using AutoMapper;
using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using MusicCollection.Repositories.AccountRepository;
using MusicCollection.Repositories.SongRepository;

namespace MusicCollection.Services.SongService
{
    public class SongService : ISongService
    {
        public ISongRepository _songRepository;
        public IMapper _mapper;
        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public async Task AddSong(SongDto newSong)
        {
            var newSongEntity = _mapper.Map<Song>(newSong);
            await _songRepository.CreateAsync(newSongEntity);
            await _songRepository.SaveAsync();
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

        public async Task DeleteSong(Guid songId)
        {
            var songToDelete = await _songRepository.FindByIdAsync(songId);
            _songRepository.Delete(songToDelete);
            await _songRepository.SaveAsync();
        }

        public async Task<List<SongDto>> GetAll()
        {
            var songs = await _songRepository.GetAll();
            return _mapper.Map< List<SongDto>>(songs);
        }
    }
}
