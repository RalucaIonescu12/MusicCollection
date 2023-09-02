using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.SongRepository
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Song>> GetSongs()
        {
            return await _table.ToListAsync();
        }
        public async Task<Song> GetSongById(Guid id)
        {
            return await FindByIdAsync(id);
        }
        public async Task<List<Song>> GetSongsByIds(List<Guid> songIds)
        {
            var songs = await _table.Where(song => songIds.Contains(song.Id)).ToListAsync();
            return songs;
        }

    }
}

