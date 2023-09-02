using AutoMapper;
using DAL.Models;
using DAL.Models.Dtos;
using DAL.Repositories.ArtistRepository;

namespace MusicCollection.Services.ArtistService
{
    public class ArtistService : IArtistService
    {
        public IArtistRepository _artistRepository;
        public IMapper _mapper;
        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<Artist> AddArtist(ArtistCreateDto newArtist)
        {
            var newArtistEntity = _mapper.Map<Artist>(newArtist);
            await _artistRepository.CreateAsync(newArtistEntity);
            await _artistRepository.SaveAsync();
            return newArtistEntity;
        }

      

        public async Task DeleteArtist(Guid artistId)
        {
            var artistToDelete = await _artistRepository.FindByIdAsync(artistId);
            _artistRepository.Delete(artistToDelete);
            await _artistRepository.SaveAsync();
        }

        public async Task<List<ArtistDto>> GetAll()
        {
            var artists = await _artistRepository.GetAll();
            return _mapper.Map< List<ArtistDto>>(artists);
        }
        public async Task<ArtistDto> GetArtistById(Guid artistId)
        {
            var artist = await _artistRepository.GetArtistById(artistId);
            return _mapper.Map<ArtistDto>(artist);
        }
    }
}
