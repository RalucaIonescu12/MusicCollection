using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;

namespace MusicCollection.Repositories.PlaylistRepository
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        public Task<List<Playlist>> GetPlaylists();

        public Task<Playlist> GetPlaylistById(Guid Id);
    }
}
