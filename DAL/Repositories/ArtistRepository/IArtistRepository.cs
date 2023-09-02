using DAL.Models;
using DAL.Repository.GenericRepository;

namespace DAL.Repositories.ArtistRepository
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        public Task<List<Artist>> GetArtists();

        public Task<Artist> GetArtistById(Guid Id);
        public Task<string> GetArtistNameById(Guid id);
    }
}
