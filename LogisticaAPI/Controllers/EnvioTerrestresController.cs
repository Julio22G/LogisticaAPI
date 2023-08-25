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
    public class EnvioTerrestresController : ControllerBase
    {
        private readonly LogisticaAPIContext _context;

        public EnvioTerrestresController(LogisticaAPIContext context)
        {
            _context = context;
        }

        // GET: api/EnvioTerrestres/Search
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<EnvioTerrestre>>> SearchEnvioTerrestresByNumeroGuia([FromQuery] string numeroGuia)
        {
            var envioTerrestresQuery = _context.EnvioTerrestre.AsQueryable();

            if (!string.IsNullOrEmpty(numeroGuia))
            {
                envioTerrestresQuery = envioTerrestresQuery.Where(e => e.NumeroGuia.Contains(numeroGuia));
            }

            var envioTerrestres = await envioTerrestresQuery.ToListAsync();
            return Ok(envioTerrestres);
        }



        // GET: api/EnvioTerrestres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvioTerrestre>>> GetEnvioTerrestre()
        {
          if (_context.EnvioTerrestre == null)
          {
              return NotFound();
          }
            return await _context.EnvioTerrestre.ToListAsync();
        }

        // GET: api/EnvioTerrestres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvioTerrestre>> GetEnvioTerrestre(int id)
        {
          if (_context.EnvioTerrestre == null)
          {
              return NotFound();
          }
            var envioTerrestre = await _context.EnvioTerrestre.FindAsync(id);

            if (envioTerrestre == null)
            {
                return NotFound();
            }

            return envioTerrestre;
        }

        // PUT: api/EnvioTerrestres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvioTerrestre(int id, EnvioTerrestre envioTerrestre)
        {
            if (id != envioTerrestre.ID)
            {
                return BadRequest();
            }

            _context.Entry(envioTerrestre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvioTerrestreExists(id))
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

        // POST: api/EnvioTerrestres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EnvioTerrestre>> PostEnvioTerrestre(EnvioTerrestre envioTerrestre)
        {
          if (_context.EnvioTerrestre == null)
          {
              return Problem("Entity set 'LogisticaAPIContext.EnvioTerrestre'  is null.");
          }
            _context.EnvioTerrestre.Add(envioTerrestre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvioTerrestre", new { id = envioTerrestre.ID }, envioTerrestre);
        }

        // DELETE: api/EnvioTerrestres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvioTerrestre(int id)
        {
            if (_context.EnvioTerrestre == null)
            {
                return NotFound();
            }
            var envioTerrestre = await _context.EnvioTerrestre.FindAsync(id);
            if (envioTerrestre == null)
            {
                return NotFound();
            }

            _context.EnvioTerrestre.Remove(envioTerrestre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvioTerrestreExists(int id)
        {
            return (_context.EnvioTerrestre?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
