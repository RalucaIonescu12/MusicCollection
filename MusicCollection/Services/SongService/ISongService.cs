
using DAL.Models;
using DAL.Models.Dtos;

namespace MusicCollection.Services.SongService
{
    public interface ISongService
    {
        public Task<List<SongDto>> GetAll();
        public  Task<SongDto> AddSong(SongCreateDto newSong, Guid artistId);


        public Task DeleteSong(Guid songId);
        public Task<SongDto> GetSongById(Guid songId);
        public Task AddSongInPlaylist(Guid playlistId, Guid songId);
        public Task<List<SongDto>> GetSongsForPlaylist(Guid playlistId);
        public Task<string> GetArtistName(SongDto songDto);
    }
}
