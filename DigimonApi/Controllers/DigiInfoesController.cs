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
    public class DigiInfoesController : ControllerBase
    {
        private readonly DigimonContext _context;

        public DigiInfoesController(DigimonContext context)
        {
            _context = context;
        }

        // GET: api/DigiInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DigiInfo>>> GetDigiInfo()
        {
            return await _context.DigiInfo.ToListAsync();
        }

        // GET: api/DigiInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DigiInfo>> GetDigiInfo(int id)
        {
            var digiInfo = await _context.DigiInfo.FindAsync(id);

            if (digiInfo == null)
            {
                return NotFound();
            }

            return digiInfo;
        }

        // PUT: api/DigiInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDigiInfo(int id, DigiInfo digiInfo)
        {
            if (id != digiInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(digiInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DigiInfoExists(id))
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

        // POST: api/DigiInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DigiInfo>> PostDigiInfo(DigiInfo digiInfo)
        {
            _context.DigiInfo.Add(digiInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DigiInfoExists(digiInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDigiInfo", new { id = digiInfo.Id }, digiInfo);
        }

        // DELETE: api/DigiInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DigiInfo>> DeleteDigiInfo(int id)
        {
            var digiInfo = await _context.DigiInfo.FindAsync(id);
            if (digiInfo == null)
            {
                return NotFound();
            }

            _context.DigiInfo.Remove(digiInfo);
            await _context.SaveChangesAsync();

            return digiInfo;
        }

        private bool DigiInfoExists(int id)
        {
            return _context.DigiInfo.Any(e => e.Id == id);
        }
    }
}
