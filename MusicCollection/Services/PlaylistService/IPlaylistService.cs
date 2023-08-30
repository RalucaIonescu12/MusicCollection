
using MusicCollection.Models;
using MusicCollection.Models.Dtos;

namespace MusicCollection.Services.PlaylistService
{
    public interface IPlaylistService
    {
        public Task<List<PlaylistDto>> GetAll();
        public Task<Playlist> AddPlaylist(PlaylistCreateDto newPlaylist);
     
        public Task DeletePlaylist(Guid playlistId);
        public Task<PlaylistDto> GetPlaylistById(Guid playlistId);
    }
}
