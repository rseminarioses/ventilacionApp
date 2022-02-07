using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentilacionAPI.Models;

namespace VentilacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrificioVentilacionController : ControllerBase
    {
        private readonly VentilacionDbContext _context;

        public OrificioVentilacionController(VentilacionDbContext context)
        {
            _context = context;
        }

        // GET: api/OrificioVentilacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrificioVentilacion>>> GetOrificioVentilacion()
        {
            return await _context.OrificioVentilacion.ToListAsync();
        }

        // GET: api/OrificioVentilacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrificioVentilacion>> GetOrificioVentilacion(int id)
        {
            var orificioVentilacion = await _context.OrificioVentilacion.FindAsync(id);

            if (orificioVentilacion == null)
            {
                return NotFound();
            }

            return orificioVentilacion;
        }

        // PUT: api/OrificioVentilacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrificioVentilacion(int id, OrificioVentilacion orificioVentilacion)
        {
            if (id != orificioVentilacion.OrificioVentilacionId)
            {
                return BadRequest();
            }

            _context.Entry(orificioVentilacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrificioVentilacionExists(id))
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

        // POST: api/OrificioVentilacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrificioVentilacion>> PostOrificioVentilacion(OrificioVentilacion orificioVentilacion)
        {
            _context.OrificioVentilacion.Add(orificioVentilacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrificioVentilacion", new { id = orificioVentilacion.OrificioVentilacionId }, orificioVentilacion);
        }

        // DELETE: api/OrificioVentilacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrificioVentilacion(int id)
        {
            var orificioVentilacion = await _context.OrificioVentilacion.FindAsync(id);
            if (orificioVentilacion == null)
            {
                return NotFound();
            }

            _context.OrificioVentilacion.Remove(orificioVentilacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrificioVentilacionExists(int id)
        {
            return _context.OrificioVentilacion.Any(e => e.OrificioVentilacionId == id);
        }
    }
}
