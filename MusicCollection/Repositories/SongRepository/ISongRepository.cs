using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;

namespace MusicCollection.Repositories.SongRepository
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        public Task<List<Song>> GetSongs();

        public Task<Song> GetSongById(Guid Id);
    }
}
