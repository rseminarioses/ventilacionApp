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
    public class FlujoAireController : ControllerBase
    {
        private readonly VentilacionDbContext _context;

        public FlujoAireController(VentilacionDbContext context)
        {
            _context = context;
        }

        // GET: api/FlujoAire
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlujoAire>>> GetFlujoAire()
        {
            return await _context.FlujoAire.ToListAsync();
        }

        // GET: api/FlujoAire/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlujoAire>> GetFlujoAire(int id)
        {
            var flujoAire = await _context.FlujoAire.FindAsync(id);

            if (flujoAire == null)
            {
                return NotFound();
            }

            return flujoAire;
        }

        // PUT: api/FlujoAire/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlujoAire(int id, FlujoAire flujoAire)
        {
            if (id != flujoAire.FlujoAireId)
            {
                return BadRequest();
            }

            _context.Entry(flujoAire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlujoAireExists(id))
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

        // POST: api/FlujoAire
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlujoAire>> PostFlujoAire(FlujoAire flujoAire)
        {
            _context.FlujoAire.Add(flujoAire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlujoAire", new { id = flujoAire.FlujoAireId }, flujoAire);
        }

        // DELETE: api/FlujoAire/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlujoAire(int id)
        {
            var flujoAire = await _context.FlujoAire.FindAsync(id);
            if (flujoAire == null)
            {
                return NotFound();
            }

            _context.FlujoAire.Remove(flujoAire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlujoAireExists(int id)
        {
            return _context.FlujoAire.Any(e => e.FlujoAireId == id);
        }
    }
}
