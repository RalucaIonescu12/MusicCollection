
using DAL.Models;
using DAL.Models.Dtos;

namespace MusicCollection.Services.ArtistService
{
    public interface IArtistService
    {
        public Task<List<ArtistDto>> GetAll();
        public Task<Artist> AddArtist(ArtistCreateDto newArtist);
     
        public Task DeleteArtist(Guid artistId);
        public Task<ArtistDto> GetArtistById(Guid artistId);
    }
}
