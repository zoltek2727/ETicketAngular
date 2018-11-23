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
    public class ReliefsController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public ReliefsController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Reliefs
        [HttpGet]
        public IEnumerable<Reliefs> GetReliefs()
        {
            return _context.Reliefs;
        }

        // GET: api/Reliefs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReliefs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reliefs = await _context.Reliefs.FindAsync(id);

            if (reliefs == null)
            {
                return NotFound();
            }

            return Ok(reliefs);
        }

        // PUT: api/Reliefs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReliefs([FromRoute] int id, [FromBody] Reliefs reliefs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reliefs.ReliefId)
            {
                return BadRequest();
            }

            _context.Entry(reliefs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReliefsExists(id))
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

        // POST: api/Reliefs
        [HttpPost]
        public async Task<IActionResult> PostReliefs([FromBody] Reliefs reliefs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Reliefs.Add(reliefs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReliefs", new { id = reliefs.ReliefId }, reliefs);
        }

        // DELETE: api/Reliefs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReliefs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reliefs = await _context.Reliefs.FindAsync(id);
            if (reliefs == null)
            {
                return NotFound();
            }

            _context.Reliefs.Remove(reliefs);
            await _context.SaveChangesAsync();

            return Ok(reliefs);
        }

        private bool ReliefsExists(int id)
        {
            return _context.Reliefs.Any(e => e.ReliefId == id);
        }
    }
}