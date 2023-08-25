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
    public class BodegasController : ControllerBase
    {
        private readonly LogisticaAPIContext _context;

        public BodegasController(LogisticaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Bodegas/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Bodega>>> SearchBodegas([FromQuery] string nombre)
        {
            var bodegasQuery = _context.Bodega.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                bodegasQuery = bodegasQuery.Where(b => b.Nombre.Contains(nombre));
            }

            var bodegas = await bodegasQuery.ToListAsync();
            return Ok(bodegas);
        }


        // GET: api/Bodegas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodega()
        {
          if (_context.Bodega == null)
          {
              return NotFound();
          }
            return await _context.Bodega.ToListAsync();
        }

        // GET: api/Bodegas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
          if (_context.Bodega == null)
          {
              return NotFound();
          }
            var bodega = await _context.Bodega.FindAsync(id);

            if (bodega == null)
            {
                return NotFound();
            }

            return bodega;
        }

        // PUT: api/Bodegas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodega(int id, Bodega bodega)
        {
            if (id != bodega.ID)
            {
                return BadRequest();
            }

            _context.Entry(bodega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodegaExists(id))
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

        // POST: api/Bodegas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bodega>> PostBodega(Bodega bodega)
        {
          if (_context.Bodega == null)
          {
              return Problem("Entity set 'LogisticaAPIContext.Bodega'  is null.");
          }
            _context.Bodega.Add(bodega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodega", new { id = bodega.ID }, bodega);
        }

        // DELETE: api/Bodegas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodega(int id)
        {
            if (_context.Bodega == null)
            {
                return NotFound();
            }
            var bodega = await _context.Bodega.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }

            _context.Bodega.Remove(bodega);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodegaExists(int id)
        {
            return (_context.Bodega?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
