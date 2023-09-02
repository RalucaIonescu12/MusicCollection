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
using MusicCollection.Services.ArtistService;
using MusicCollection.Services.PlaylistService;

namespace MusicCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly MusicCollectionContext _context;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        public ArtistsController(MusicCollectionContext context, IMapper mapper, IArtistService artistService)
        {
            _context = context;
            _mapper = mapper;
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDto>>> GetArtists()
        {
          if (_context.Artists == null)
          {
              return NotFound();
          }
            //return await _context.Artists.ToListAsync();
            return Ok(await _artistService.GetAll());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDto>> GetArtist(Guid id)
        {
          if (_context.Artists == null)
          {
              return NotFound();
          }
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }
            var artistDto = _mapper.Map<ArtistDto>(artist);
            return Ok(artistDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(Guid id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(ArtistCreateDto artistDto)
        {
          if (_context.Artists == null)
          {
              return Problem("Entity set 'MusicCollectionContext.Artists'  is null.");
          }
            var artistEntity = _mapper.Map<Artist>(artistDto);
            _context.Artists.Add(artistEntity);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetArtist", new { id = artistEntity.Id }, artistEntity);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(Guid id)
        {
            if (_context.Artists == null)
            {
                return NotFound();
            }
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistExists(Guid id)
        {
            return (_context.Artists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
