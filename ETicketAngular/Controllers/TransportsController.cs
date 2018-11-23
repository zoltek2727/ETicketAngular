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
    public class TransportsController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public TransportsController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Transports
        [HttpGet]
        public IEnumerable<Transports> GetTransports()
        {
            return _context.Transports;
        }

        // GET: api/Transports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransports([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transports = await _context.Transports.FindAsync(id);

            if (transports == null)
            {
                return NotFound();
            }

            return Ok(transports);
        }

        // PUT: api/Transports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransports([FromRoute] int id, [FromBody] Transports transports)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transports.TransportId)
            {
                return BadRequest();
            }

            _context.Entry(transports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportsExists(id))
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

        // POST: api/Transports
        [HttpPost]
        public async Task<IActionResult> PostTransports([FromBody] Transports transports)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Transports.Add(transports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransports", new { id = transports.TransportId }, transports);
        }

        // DELETE: api/Transports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransports([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transports = await _context.Transports.FindAsync(id);
            if (transports == null)
            {
                return NotFound();
            }

            _context.Transports.Remove(transports);
            await _context.SaveChangesAsync();

            return Ok(transports);
        }

        private bool TransportsExists(int id)
        {
            return _context.Transports.Any(e => e.TransportId == id);
        }
    }
}