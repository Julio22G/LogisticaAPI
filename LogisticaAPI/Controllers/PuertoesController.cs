using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaAPI.Data;
using LogisticaAPI.Models;

namespace LogisticaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuertoesController : ControllerBase
    {
        private readonly LogisticaAPIContext _context;

        public PuertoesController(LogisticaAPIContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPuertos(string keyword)
        {
            var puertos = await _context.Puerto
                .Where(p => p.Nombre.Contains(keyword))
                .ToListAsync();

            return Ok(puertos);
        }


        // GET: api/Puertoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puerto>>> GetPuerto()
        {
          if (_context.Puerto == null)
          {
              return NotFound();
          }
            return await _context.Puerto.ToListAsync();
        }

        // GET: api/Puertoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puerto>> GetPuerto(int id)
        {
          if (_context.Puerto == null)
          {
              return NotFound();
          }
            var puerto = await _context.Puerto.FindAsync(id);

            if (puerto == null)
            {
                return NotFound();
            }

            return puerto;
        }

        // PUT: api/Puertoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuerto(int id, Puerto puerto)
        {
            if (id != puerto.ID)
            {
                return BadRequest();
            }

            _context.Entry(puerto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuertoExists(id))
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

        // POST: api/Puertoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puerto>> PostPuerto(Puerto puerto)
        {
          if (_context.Puerto == null)
          {
              return Problem("Entity set 'LogisticaAPIContext.Puerto'  is null.");
          }
            _context.Puerto.Add(puerto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuerto", new { id = puerto.ID }, puerto);
        }

        // DELETE: api/Puertoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuerto(int id)
        {
            if (_context.Puerto == null)
            {
                return NotFound();
            }
            var puerto = await _context.Puerto.FindAsync(id);
            if (puerto == null)
            {
                return NotFound();
            }

            _context.Puerto.Remove(puerto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuertoExists(int id)
        {
            return (_context.Puerto?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
