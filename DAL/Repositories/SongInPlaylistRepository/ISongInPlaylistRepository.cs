using DAL.Models;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories.SongInPlaylistRepository
{
    public interface ISongInPlaylistRepository : IGenericRepository<SongInPlaylist>
    {
        public Task AddSongInPlaylist(Guid playlistId, Guid songId);
        public Task<List<Guid>> GetSongIdsForPlaylist(Guid playlistId);
        public Task<int> CountSongs(Guid id);
    }
}
