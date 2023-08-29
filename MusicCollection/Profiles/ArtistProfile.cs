using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using AutoMapper;
namespace MusicCollection.Profiles
{
    public class ArtistProfile:Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, ArtistCreateDto>();
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDto, Artist>();
            CreateMap< ArtistCreateDto, Artist>();
        }
    }
}
