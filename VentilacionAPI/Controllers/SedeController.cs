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
    public class SedeController : ControllerBase
    {
        private readonly VentilacionDbContext _context;

        public SedeController(VentilacionDbContext context)
        {
            _context = context;
        }

        // GET: api/Sede
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSede()
        {
            return await _context.Sede.ToListAsync();
        }

        // GET: api/Sede/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(int id)
        {
            var sede = await _context.Sede.FindAsync(id);

            if (sede == null)
            {
                return NotFound();
            }

            return sede;
        }

        // PUT: api/Sede/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSede(int id, Sede sede)
        {
            if (id != sede.SedeId)
            {
                return BadRequest();
            }

            _context.Entry(sede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sede
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sede>> PostSede(Sede sede)
        {
            _context.Sede.Add(sede);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSede", new { id = sede.SedeId }, sede);
        }

        // DELETE: api/Sede/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede(int id)
        {
            var sede = await _context.Sede.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            _context.Sede.Remove(sede);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SedeExists(int id)
        {
            return _context.Sede.Any(e => e.SedeId == id);
        }
    }
}
