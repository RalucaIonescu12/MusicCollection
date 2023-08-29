using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MusicCollection.Repositories.SongRepository
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Song>> GetSongs()
        {
            return await _table.ToListAsync();
        }
    }
}

