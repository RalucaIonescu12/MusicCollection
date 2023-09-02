using DAL.Models;
using DAL.Models.Dtos;
using AutoMapper;
namespace MusicCollection.Profiles
{
    public class PlaylistProfile:Profile
    {
        public PlaylistProfile()
        {
            CreateMap<Playlist, PlaylistCreateDto>();
            CreateMap<Playlist, PlaylistDto>();
            CreateMap<PlaylistDto, Playlist>();
            CreateMap<PlaylistCreateDto, Playlist>();
        }
    }
}
