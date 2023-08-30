using MusicCollection.Models;
using MusicCollection.Repository.GenericRepository;

namespace MusicCollection.Repositories.ArtistRepository
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        public Task<List<Artist>> GetArtists();

        public Task<Artist> GetArtistById(Guid Id);
    }
}
