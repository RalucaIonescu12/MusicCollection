using DAL.Models;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories.PlaylistRepository
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        public Task<List<Playlist>> GetPlaylists();

        public Task<Playlist> GetPlaylistById(Guid Id);
        public Task<List<Playlist>>GetPlaylistsForAccount(Guid id);
    }
}
