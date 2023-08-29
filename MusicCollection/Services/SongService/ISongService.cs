
using MusicCollection.Models;
using MusicCollection.Models.Dtos;

namespace MusicCollection.Services.SongService
{
    public interface ISongService
    {
        public Task<List<SongDto>> GetAll();
        public Task AddSong(SongDto newSong);
     
        public Task DeleteSong(Guid songId);
    }
}
