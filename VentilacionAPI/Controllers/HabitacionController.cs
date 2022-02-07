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
    public class HabitacionController : ControllerBase
    {
        private readonly VentilacionDbContext _context;

        public HabitacionController(VentilacionDbContext context)
        {
            _context = context;
        }

        // GET: api/Habitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitacion()
        {
            return await _context.Habitacion.ToListAsync();
        }

        // GET: api/Habitacion/Sede/5
        [HttpGet("Sede/{id}")]
        public async Task<ActionResult<Habitacion>> GetHabitacion(int id)
        {
            var habitacion = await _context.Habitacion.FindAsync(id);            

            if (habitacion == null)
            {
                return NotFound();
            }

            return Ok(habitacion);
        }

        // PUT: api/Habitacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitacion(int id, Habitacion habitacion)
        {
            if (id != habitacion.HabitacionId)
            {
                return BadRequest();
            }

            _context.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(id))
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

        // POST: api/Habitacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habitacion>> PostHabitacion(Habitacion habitacion)
        {
            _context.Habitacion.Add(habitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitacion", new { id = habitacion.HabitacionId }, habitacion);
        }

        // DELETE: api/Habitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacion(int id)
        {
            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.Habitacion.Remove(habitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitacion.Any(e => e.HabitacionId == id);
        }
    }
}
