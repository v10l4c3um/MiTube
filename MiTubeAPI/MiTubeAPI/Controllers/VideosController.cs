using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiTubeAPI.Data;
using MiTubeModels;

namespace MiTubeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly MiTubeAPIContext _context;

        public VideosController(MiTubeAPIContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideo()
        {
          if (_context.Video == null)
          {
              return NotFound();
          }
            return await _context.Video.ToListAsync();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideo(Guid id)
        {
          if (_context.Video == null)
          {
              return NotFound();
          }
            var video = await _context.Video.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideo(Guid id, Video video)
        {
            if (id != video.Id)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideo(Video video)
        {
          if (_context.Video == null)
          {
              return Problem("Entity set 'MiTubeAPIContext.Video'  is null.");
          }
            _context.Video.Add(video);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideo", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(Guid id)
        {
            if (_context.Video == null)
            {
                return NotFound();
            }
            var video = await _context.Video.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Video.Remove(video);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoExists(Guid id)
        {
            return (_context.Video?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
