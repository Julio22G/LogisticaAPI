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
    public class TipoDeProductoesController : ControllerBase
    {
        private readonly LogisticaAPIContext _context;

        public TipoDeProductoesController(LogisticaAPIContext context)
        {
            _context = context;
        }

        // GET: api/TipoDeProductoes/search
        [HttpGet("search")]
        public async Task<IActionResult> SearchTipoDeProductos(string keyword)
        {
            var tipoDeProductos = await _context.TipoDeProducto
                .Where(tp => tp.Nombre.Contains(keyword))
                .ToListAsync();

            return Ok(tipoDeProductos);
        }


        // GET: api/TipoDeProductoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDeProducto>>> GetTipoDeProducto()
        {
          if (_context.TipoDeProducto == null)
          {
              return NotFound();
          }
            return await _context.TipoDeProducto.ToListAsync();
        }

        // GET: api/TipoDeProductoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDeProducto>> GetTipoDeProducto(int id)
        {
          if (_context.TipoDeProducto == null)
          {
              return NotFound();
          }
            var tipoDeProducto = await _context.TipoDeProducto.FindAsync(id);

            if (tipoDeProducto == null)
            {
                return NotFound();
            }

            return tipoDeProducto;
        }

        // PUT: api/TipoDeProductoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDeProducto(int id, TipoDeProducto tipoDeProducto)
        {
            if (id != tipoDeProducto.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipoDeProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeProductoExists(id))
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

        // POST: api/TipoDeProductoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDeProducto>> PostTipoDeProducto(TipoDeProducto tipoDeProducto)
        {
          if (_context.TipoDeProducto == null)
          {
              return Problem("Entity set 'LogisticaAPIContext.TipoDeProducto'  is null.");
          }
            _context.TipoDeProducto.Add(tipoDeProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDeProducto", new { id = tipoDeProducto.ID }, tipoDeProducto);
        }

        // DELETE: api/TipoDeProductoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDeProducto(int id)
        {
            if (_context.TipoDeProducto == null)
            {
                return NotFound();
            }
            var tipoDeProducto = await _context.TipoDeProducto.FindAsync(id);
            if (tipoDeProducto == null)
            {
                return NotFound();
            }

            _context.TipoDeProducto.Remove(tipoDeProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDeProductoExists(int id)
        {
            return (_context.TipoDeProducto?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
