using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UFOAPI.Data;
using UFOAPI.Models;

namespace UFOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliensController : ControllerBase
    {
        private readonly UFOAPIContext _context;

        public AliensController(UFOAPIContext context)
        {
            _context = context;
        }

        // GET: api/Aliens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alien>>> GetAlien()
        {
            return await _context.Alien.ToListAsync();
        }

        // GET: api/Aliens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alien>> GetAlien(int id)
        {
            var alien = await _context.Alien.FindAsync(id);

            if (alien == null)
            {
                return NotFound();
            }

            return alien;
        }

        // PUT: api/Aliens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlien(int id, Alien alien)
        {
            if (id != alien.Id)
            {
                return BadRequest();
            }

            _context.Entry(alien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlienExists(id))
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

        // POST: api/Aliens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alien>> PostAlien(Alien alien)
        {
            _context.Alien.Add(alien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlien", new { id = alien.Id }, alien);
        }

        // DELETE: api/Aliens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlien(int id)
        {
            var alien = await _context.Alien.FindAsync(id);
            if (alien == null)
            {
                return NotFound();
            }

            _context.Alien.Remove(alien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlienExists(int id)
        {
            return _context.Alien.Any(e => e.Id == id);
        }
    }
}
