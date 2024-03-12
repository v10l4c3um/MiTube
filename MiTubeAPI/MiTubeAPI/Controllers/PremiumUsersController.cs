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
    public class PremiumUsersController : ControllerBase
    {
        private readonly MiTubeAPIContext _context;

        public PremiumUsersController(MiTubeAPIContext context)
        {
            _context = context;
        }

        // GET: api/PremiumUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PremiumUser>>> GetPremiumUser()
        {
          if (_context.PremiumUser == null)
          {
              return NotFound();
          }
            return await _context.PremiumUser.ToListAsync();
        }

        // GET: api/PremiumUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PremiumUser>> GetPremiumUser(Guid id)
        {
          if (_context.PremiumUser == null)
          {
              return NotFound();
          }
            var premiumUser = await _context.PremiumUser.FindAsync(id);

            if (premiumUser == null)
            {
                return NotFound();
            }

            return premiumUser;
        }

        // PUT: api/PremiumUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremiumUser(Guid id, PremiumUser premiumUser)
        {
            if (id != premiumUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(premiumUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PremiumUserExists(id))
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

        // POST: api/PremiumUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PremiumUser>> PostPremiumUser(PremiumUser premiumUser)
        {
          if (_context.PremiumUser == null)
          {
              return Problem("Entity set 'MiTubeAPIContext.PremiumUser'  is null.");
          }
            _context.PremiumUser.Add(premiumUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPremiumUser", new { id = premiumUser.Id }, premiumUser);
        }

        // DELETE: api/PremiumUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremiumUser(Guid id)
        {
            if (_context.PremiumUser == null)
            {
                return NotFound();
            }
            var premiumUser = await _context.PremiumUser.FindAsync(id);
            if (premiumUser == null)
            {
                return NotFound();
            }

            _context.PremiumUser.Remove(premiumUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PremiumUserExists(Guid id)
        {
            return (_context.PremiumUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
