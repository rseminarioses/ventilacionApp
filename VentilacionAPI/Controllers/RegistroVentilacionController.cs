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
    public class RegistroVentilacionController : ControllerBase
    {
        private readonly VentilacionDbContext _context;

        public RegistroVentilacionController(VentilacionDbContext context)
        {
            _context = context;
        }

        // GET: api/RegistroVentilacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroVentilacion>>> GetRegistroVentilacion()
        {
            return await _context.RegistroVentilacion.ToListAsync();
        }

        // GET: api/RegistroVentilacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroVentilacion>> GetRegistroVentilacion(int id)
        {
            var registroVentilacion = await _context.RegistroVentilacion.FindAsync(id);

            if (registroVentilacion == null)
            {
                return NotFound();
            }

            return registroVentilacion;
        }

        // PUT: api/RegistroVentilacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroVentilacion(int id, RegistroVentilacion registroVentilacion)
        {
            if (id != registroVentilacion.RegistroVentilacionId)
            {
                return BadRequest();
            }

            _context.Entry(registroVentilacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroVentilacionExists(id))
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

        // POST: api/RegistroVentilacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroVentilacion>> PostRegistroVentilacion(RegistroVentilacion registroVentilacion)
        {
            _context.RegistroVentilacion.Add(registroVentilacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroVentilacion", new { id = registroVentilacion.RegistroVentilacionId }, registroVentilacion);
        }

        // DELETE: api/RegistroVentilacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistroVentilacion(int id)
        {
            var registroVentilacion = await _context.RegistroVentilacion.FindAsync(id);
            if (registroVentilacion == null)
            {
                return NotFound();
            }

            _context.RegistroVentilacion.Remove(registroVentilacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroVentilacionExists(int id)
        {
            return _context.RegistroVentilacion.Any(e => e.RegistroVentilacionId == id);
        }
    }
}
