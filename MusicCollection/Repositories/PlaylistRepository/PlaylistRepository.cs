using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MusicCollection.Repositories.PlaylistRepository
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Playlist>> GetPlaylists()
        {
            return await _table.ToListAsync();
        }
        public async Task<Playlist> GetPlaylistById(Guid id)
        {
            return await FindByIdAsync(id);
        }
    }
}

