using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DAL.Repositories.SongInPlaylistRepository
{
    public class SongInPlaylistRepository : GenericRepository<SongInPlaylist>, ISongInPlaylistRepository
    {
        public SongInPlaylistRepository(MusicCollectionContext context) : base(context) { }

        public async Task AddSongInPlaylist(Guid playlistId, Guid songId)
        {
            SongInPlaylist songInPlaylist = new SongInPlaylist();
            songInPlaylist.PlaylistId = playlistId;
            songInPlaylist.SongId = songId;
            await CreateAsync(songInPlaylist);
        }
        public async Task<List<Guid>> GetSongIdsForPlaylist(Guid playlistId)
        {
            var songIds = new List<Guid>();
            songIds =  _table.Where(sp => sp.PlaylistId == playlistId).Select(sp => sp.SongId).ToList(); 
            return songIds;

        }
        public  async Task<int> CountSongs(Guid id)
        {
            return   _table.Where(sp=>sp.PlaylistId==id).Count();
        }
    }
}

