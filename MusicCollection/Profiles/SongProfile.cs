using MusicCollection.Models;
using MusicCollection.Models.Dtos;
using AutoMapper;
namespace MusicCollection.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<Song, SongCreateDto>();
            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();
            CreateMap<SongCreateDto, Song>();
        }
    }
}
