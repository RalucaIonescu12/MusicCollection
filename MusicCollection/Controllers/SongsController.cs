using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using DAL.Data;
using DAL.Models;
using DAL.Models.Dtos;
using MusicCollection.Services.SongService;

namespace MusicCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly MusicCollectionContext _context;
        private readonly IMapper _mapper;
        private readonly ISongService _songService;
        public SongsController(MusicCollectionContext context, IMapper mapper, ISongService songService)
        {
            _context = context;
            _mapper = mapper;
            _songService = songService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SongDto>>> GetSongs()
        {
          if (_context.Songs == null)
          {
              return NotFound();
          }
            var songDtos = await _songService.GetAll();
            foreach (var song in songDtos)
            {
                song.ArtistName = await _songService.GetArtistName(song);
            }

            return Ok(songDtos);
        }
        [HttpGet("get-songs-for-playlist/{playlistId}")]
        public async Task<ActionResult<List<SongDto>>> GetSongsInPlaylist(Guid playlistId)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }
            var songDtos = await _songService.GetSongsForPlaylist(playlistId);
            foreach (var song in songDtos)
            {
                song.ArtistName = await _songService.GetArtistName(song);
            }
            return Ok(songDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SongDto>> GetSong(Guid id)
        {
          if (_context.Songs == null)
          {
              return NotFound();
          }
            var songDto = await _songService.GetSongById(id);
            if (songDto == null)
            {
                return NotFound();
            }
            songDto.ArtistName =await _songService.GetArtistName(songDto);
            return Ok(songDto);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(Guid id, Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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
        
        [HttpPost("{artistId}")]
        public async Task<ActionResult<SongDto>> PostSong(Guid artistId,SongCreateDto songCreateDto)
        {
          if (_context.Songs == null)
          {
              return Problem("Entity set 'MusicCollectionContext.Songs'  is null.");
          }
            var songDto = await _songService.AddSong(songCreateDto, artistId);

            return CreatedAtAction("GetSong", new { id = songDto.Id }, songDto);
        }
        [HttpPost("add-song-in-playlist/{playlistId}/{songId}")]
        public async Task<ActionResult> AddSongInPlaylist(Guid playlistId, Guid songId)
        {
            if (_context.Songs == null)
            {
                return Problem("Entity set 'MusicCollectionContext.Songs'  is null.");
            }

            await _songService.AddSongInPlaylist(playlistId,songId);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(Guid id)
        {
            if (_context.Songs == null)
            {
                return NotFound();
            }
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(Guid id)
        {
            return (_context.Songs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
