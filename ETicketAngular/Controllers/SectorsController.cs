using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETicketAngular.Models;

namespace ETicketAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public SectorsController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Sectors
        [HttpGet]
        public IEnumerable<Sectors> GetSectors()
        {
            return _context.Sectors;
        }

        // GET: api/Sectors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sectors = await _context.Sectors.FindAsync(id);

            if (sectors == null)
            {
                return NotFound();
            }

            return Ok(sectors);
        }

        // PUT: api/Sectors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectors([FromRoute] int id, [FromBody] Sectors sectors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sectors.SectorId)
            {
                return BadRequest();
            }

            _context.Entry(sectors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorsExists(id))
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

        // POST: api/Sectors
        [HttpPost]
        public async Task<IActionResult> PostSectors([FromBody] Sectors sectors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sectors.Add(sectors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSectors", new { id = sectors.SectorId }, sectors);
        }

        // DELETE: api/Sectors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sectors = await _context.Sectors.FindAsync(id);
            if (sectors == null)
            {
                return NotFound();
            }

            _context.Sectors.Remove(sectors);
            await _context.SaveChangesAsync();

            return Ok(sectors);
        }

        private bool SectorsExists(int id)
        {
            return _context.Sectors.Any(e => e.SectorId == id);
        }
    }
}