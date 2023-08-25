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
    public class EnvioMaritimoesController : ControllerBase
    {
        private readonly LogisticaAPIContext _context;

        public EnvioMaritimoesController(LogisticaAPIContext context)
        {
            _context = context;
        }

        // GET: api/EnvioMaritimoes/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<EnvioMaritimo>>> SearchEnvioMaritimosByNumeroGuia([FromQuery] string numeroGuia)
        {
            var envioMaritimosQuery = _context.EnvioMaritimo.AsQueryable();

            if (!string.IsNullOrEmpty(numeroGuia))
            {
                envioMaritimosQuery = envioMaritimosQuery.Where(e => e.NumeroGuia.Contains(numeroGuia));
            }

            var envioMaritimos = await envioMaritimosQuery.ToListAsync();
            return Ok(envioMaritimos);
        }


        // GET: api/EnvioMaritimoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvioMaritimo>>> GetEnvioMaritimo()
        {
          if (_context.EnvioMaritimo == null)
          {
              return NotFound();
          }
            return await _context.EnvioMaritimo.ToListAsync();
        }

        // GET: api/EnvioMaritimoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvioMaritimo>> GetEnvioMaritimo(int id)
        {
          if (_context.EnvioMaritimo == null)
          {
              return NotFound();
          }
            var envioMaritimo = await _context.EnvioMaritimo.FindAsync(id);

            if (envioMaritimo == null)
            {
                return NotFound();
            }

            return envioMaritimo;
        }

        // PUT: api/EnvioMaritimoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvioMaritimo(int id, EnvioMaritimo envioMaritimo)
        {
            if (id != envioMaritimo.ID)
            {
                return BadRequest();
            }

            _context.Entry(envioMaritimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvioMaritimoExists(id))
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

        // POST: api/EnvioMaritimoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnvioMaritimo>> PostEnvioMaritimo(EnvioMaritimo envioMaritimo)
        {
          if (_context.EnvioMaritimo == null)
          {
              return Problem("Entity set 'LogisticaAPIContext.EnvioMaritimo'  is null.");
          }
            _context.EnvioMaritimo.Add(envioMaritimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvioMaritimo", new { id = envioMaritimo.ID }, envioMaritimo);
        }

        // DELETE: api/EnvioMaritimoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvioMaritimo(int id)
        {
            if (_context.EnvioMaritimo == null)
            {
                return NotFound();
            }
            var envioMaritimo = await _context.EnvioMaritimo.FindAsync(id);
            if (envioMaritimo == null)
            {
                return NotFound();
            }

            _context.EnvioMaritimo.Remove(envioMaritimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvioMaritimoExists(int id)
        {
            return (_context.EnvioMaritimo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
