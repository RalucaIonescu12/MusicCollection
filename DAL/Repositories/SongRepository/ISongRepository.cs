using DAL.Models;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories.SongRepository
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        public Task<List<Song>> GetSongs();

        public Task<Song> GetSongById(Guid Id);
        public Task<List<Song>> GetSongsByIds(List<Guid> songIds);
    }
}
