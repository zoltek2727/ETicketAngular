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
    public class PerformersController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public PerformersController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Performers
        [HttpGet]
        public IEnumerable<Performers> GetPerformers()
        {
            return _context.Performers;
        }

        // GET: api/Performers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var performers = await _context.Performers.FindAsync(id);

            if (performers == null)
            {
                return NotFound();
            }

            return Ok(performers);
        }

        // PUT: api/Performers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformers([FromRoute] int id, [FromBody] Performers performers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != performers.PerformerId)
            {
                return BadRequest();
            }

            _context.Entry(performers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformersExists(id))
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

        // POST: api/Performers
        [HttpPost]
        public async Task<IActionResult> PostPerformers([FromBody] Performers performers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Performers.Add(performers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformers", new { id = performers.PerformerId }, performers);
        }

        // DELETE: api/Performers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var performers = await _context.Performers.FindAsync(id);
            if (performers == null)
            {
                return NotFound();
            }

            _context.Performers.Remove(performers);
            await _context.SaveChangesAsync();

            return Ok(performers);
        }

        private bool PerformersExists(int id)
        {
            return _context.Performers.Any(e => e.PerformerId == id);
        }
    }
}