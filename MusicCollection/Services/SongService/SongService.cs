using AutoMapper;
using DAL.Models;
using DAL.Models.Dtos;
using DAL.Repositories.ArtistRepository;
using DAL.Repositories.SongInPlaylistRepository;
using DAL.Repositories.SongRepository;

namespace MusicCollection.Services.SongService
{
    public class SongService : ISongService
    {
        public ISongRepository _songRepository;
        public ISongInPlaylistRepository _songInPlaylistRepository;
        public IMapper _mapper;
        public IArtistRepository _artistRepository;
        public SongService(ISongRepository songRepository, IMapper mapper, ISongInPlaylistRepository songInPlaylistRepository, IArtistRepository artistRepository)

        {
            _songRepository = songRepository;
            _mapper = mapper;
            _songInPlaylistRepository = songInPlaylistRepository;
            _artistRepository = artistRepository;
        }

        public async Task<SongDto> AddSong(SongCreateDto newSong, Guid artistId)
        {

            var newSongEntity = _mapper.Map<Song>(newSong);
            newSongEntity.Artist =  _artistRepository.FindById(artistId);
            newSongEntity.ArtistId = artistId;
            await _songRepository.CreateAsync(newSongEntity);
            await _songRepository.SaveAsync();
            var songDto = _mapper.Map<SongDto>(newSongEntity);
            songDto.ArtistName = await _artistRepository.GetArtistNameById(artistId);
            return songDto;
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
        public async Task<SongDto> GetSongById(Guid songId)
        {
            var song = await _songRepository.GetSongById(songId);
            return _mapper.Map<SongDto>(song);
        }
        public async Task AddSongInPlaylist(Guid playlistId, Guid songId)
        {
            await _songInPlaylistRepository.AddSongInPlaylist(playlistId, songId);
            await _songInPlaylistRepository.SaveAsync();
        }
        public async Task<List<SongDto>> GetSongsForPlaylist(Guid playlistId)
        {
            var songIds = await _songInPlaylistRepository.GetSongIdsForPlaylist(playlistId);
            var songs = await _songRepository.GetSongsByIds(songIds);
            return _mapper.Map<List<SongDto>>(songs);

        }
        public async Task<string> GetArtistName(SongDto songDto)
        {
            return await _artistRepository.GetArtistNameById(songDto.ArtistId);
        }
    }
}
