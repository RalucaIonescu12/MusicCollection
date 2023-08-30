
using MusicCollection.Models;
using MusicCollection.Models.Dtos;

namespace MusicCollection.Services.SongService
{
    public interface ISongService
    {
        public Task<List<SongDto>> GetAll();
        public Task<Song> AddSong(SongCreateDto newSong);
     
        public Task DeleteSong(Guid songId);
        public Task<SongDto> GetSongById(Guid songId);
    }
}
