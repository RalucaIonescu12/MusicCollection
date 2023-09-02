using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Data;
using DAL.Models;
using DAL.Models.Dtos;
using MusicCollection.Services.PlaylistService;

namespace MusicCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly MusicCollectionContext _context;
        private readonly IMapper _mapper;
        private readonly IPlaylistService _playlistService;
        public PlaylistsController(MusicCollectionContext context, IMapper mapper,IPlaylistService playlistService)
        {
            _context = context;
            _mapper = mapper;
            _playlistService = playlistService;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistDto>>> GetPlaylists()
        {
          if (_context.Playlists == null)
          {
              return NotFound();
          }
            return Ok(await _playlistService.GetAll());
        }
        [HttpGet("get-playlists-for-account/{accountId}")]
        public async Task<ActionResult<IEnumerable<PlaylistDto>>> GetPlaylistsForAccount(Guid accountId)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }
            return Ok(await _playlistService.GetPlaylistsForAccount(accountId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDto>> GetPlaylist(Guid id)
        {
          if (_context.Playlists == null)
          {
              return NotFound();
          }
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }
            var playlistDto= _mapper.Map<PlaylistDto>(playlist);
            return Ok(playlistDto);
        }
    

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(Guid id, Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("{accountId}")]
        public async Task<ActionResult<Playlist>> PostPlaylist(Guid accountId,PlaylistCreateDto playlistDto)
        {
          if (_context.Playlists == null)
          {
              return Problem("Entity set 'MusicCollectionContext.Playlists'  is null.");
          }
            var playlistEntity = _mapper.Map<Playlist>(playlistDto);
            playlistEntity.AccountId = accountId;

            _context.Playlists.Add(playlistEntity);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaylist", new { id = playlistEntity.Id }, playlistEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(Guid id)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistExists(Guid id)
        {
            return (_context.Playlists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
