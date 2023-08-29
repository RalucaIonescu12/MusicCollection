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
using MusicCollection.Data;
using MusicCollection.Models;
using MusicCollection.Models.Dtos;
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
         
            return Ok(await _songService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SongDto>> GetSong(Guid id)
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
            var songDto = _mapper.Map<SongDto>(song);
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
        public async Task<ActionResult<Song>> PostSong(Guid artistId,SongCreateDto songDto)
        {
          if (_context.Songs == null)
          {
              return Problem("Entity set 'MusicCollectionContext.Songs'  is null.");
          }
            var songEntity = _mapper.Map<Song>(songDto);
            songEntity.ArtistId = artistId;

            _context.Songs.Add(songEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = songEntity.Id }, songEntity);
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
