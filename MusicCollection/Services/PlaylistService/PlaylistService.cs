using AutoMapper;
using DAL.Models;
using DAL.Models.Dtos;
using DAL.Repositories.PlaylistRepository;
using DAL.Repositories.SongInPlaylistRepository;
using Microsoft.Identity.Client;

namespace MusicCollection.Services.PlaylistService
{
    public class PlaylistService : IPlaylistService
    {
        public IPlaylistRepository _playlistRepository;
        public ISongInPlaylistRepository _songInPlaylistRepository;
        public IMapper _mapper;
        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper, ISongInPlaylistRepository songInPlaylistRepository)
        {
            _playlistRepository = playlistRepository;
            _mapper = mapper;
            _songInPlaylistRepository = songInPlaylistRepository;
        }

        public async Task<Playlist> AddPlaylist(PlaylistCreateDto newPlaylist)
        {
            var newPlaylistEntity = _mapper.Map<Playlist>(newPlaylist);
            await _playlistRepository.CreateAsync(newPlaylistEntity);
            await _playlistRepository.SaveAsync();
            return newPlaylistEntity;
        }

        public async Task<List<PlaylistDto>> GetPlaylistsForAccount(Guid accountId)
        {
            var playlists = await _playlistRepository.GetPlaylistsForAccount(accountId);

            var playlistsDtos = _mapper.Map<List<PlaylistDto>>(playlists);

            foreach (var playlistDto in playlistsDtos)
            {
                playlistDto.numberOfSongs = await _songInPlaylistRepository.CountSongs(playlistDto.Id);
            }

            return playlistsDtos;
        }


        public async Task DeletePlaylist(Guid playlistId)
        {
            var playlistToDelete = await _playlistRepository.FindByIdAsync(playlistId);
            _playlistRepository.Delete(playlistToDelete);
            await _playlistRepository.SaveAsync();
        }

        public async Task<List<PlaylistDto>> GetAll()
        {
            var playlists = await _playlistRepository.GetAll();
            return _mapper.Map< List<PlaylistDto>>(playlists);
        }
        public async Task<PlaylistDto> GetPlaylistById(Guid playlistId)
        {
            var playlist = await _playlistRepository.GetPlaylistById(playlistId);
            return _mapper.Map<PlaylistDto>(playlist);
        }
       
    }
}
