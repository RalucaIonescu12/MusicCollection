
using DAL.Models;
using DAL.Models.Dtos;
using Microsoft.Build.Framework;

namespace MusicCollection.Services.PlaylistService
{
    public interface IPlaylistService
    {
        public Task<List<PlaylistDto>> GetAll();
        public Task<Playlist> AddPlaylist(PlaylistCreateDto newPlaylist);
     
        public Task DeletePlaylist(Guid playlistId);
        public Task<PlaylistDto> GetPlaylistById(Guid playlistId);
        public Task<List<PlaylistDto>> GetPlaylistsForAccount(Guid accountId);
        

    }
}
