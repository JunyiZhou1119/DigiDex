using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigimonApi.Models;

namespace DigimonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigiDexesController : ControllerBase
    {
        private readonly DigimonContext _context;

        public DigiDexesController(DigimonContext context)
        {
            _context = context;
        }

        // GET: api/DigiDexes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DigiDex>>> GetDigiDex()
        {
            return await _context.DigiDex.ToListAsync();
        }

        // GET: api/DigiDexes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DigiDex>> GetDigiDex(int id)
        {
            var digiDex = await _context.DigiDex.FindAsync(id);

            if (digiDex == null)
            {
                return NotFound();
            }

            return digiDex;
        }

        // PUT: api/DigiDexes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDigiDex(int id, DigiDex digiDex)
        {
            if (id != digiDex.DigiId)
            {
                return BadRequest();
            }

            _context.Entry(digiDex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DigiDexExists(id))
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

        // POST: api/DigiDexes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DigiDex>> PostDigiDex(DigiDex digiDex)
        {
            _context.DigiDex.Add(digiDex);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DigiDexExists(digiDex.DigiId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDigiDex", new { id = digiDex.DigiId }, digiDex);
        }

        // DELETE: api/DigiDexes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DigiDex>> DeleteDigiDex(int id)
        {
            var digiDex = await _context.DigiDex.FindAsync(id);
            if (digiDex == null)
            {
                return NotFound();
            }

            _context.DigiDex.Remove(digiDex);
            await _context.SaveChangesAsync();

            return digiDex;
        }

        private bool DigiDexExists(int id)
        {
            return _context.DigiDex.Any(e => e.DigiId == id);
        }
    }
}
