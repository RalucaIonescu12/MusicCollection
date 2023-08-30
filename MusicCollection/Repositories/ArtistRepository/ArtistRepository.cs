using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MusicCollection.Repositories.ArtistRepository
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(MusicCollectionContext context) : base(context) { }

        public async Task<List<Artist>> GetArtists()
        {
            return await _table.ToListAsync();
        }
        public async Task<Artist> GetArtistById(Guid id)
        {
            return await FindByIdAsync(id);
        }
    }
}

