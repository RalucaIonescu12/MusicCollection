using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DAL.Repositories.PlaylistRepository
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Playlist>> GetPlaylists()
        {
            return await  GetAll();
        }
        public async Task<Playlist> GetPlaylistById(Guid id)
        {
            return await FindByIdAsync(id);
        }
        public async Task<List<Playlist>> GetPlaylistsForAccount(Guid id)
        {
           
            return await _table.Where(p => p.AccountId == id).AsNoTracking().ToListAsync();
        }
      

    }
}

