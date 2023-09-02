using DAL.Data;
using DAL.Models;
using DAL.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.ArtistRepository
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
        public async Task<string> GetArtistNameById(Guid id)
        {
            Console.Write(_table.FirstOrDefault(a => a.Id == id).Name);
            return  _table.FirstOrDefault(a=>a.Id==id).Name;
        }
    }
}

