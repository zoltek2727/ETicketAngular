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
    public class TicketsController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public TicketsController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public IEnumerable<Tickets> GetTickets()
        {
            return _context.Tickets;
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTickets([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tickets = await _context.Tickets.FindAsync(id);

            if (tickets == null)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets([FromRoute] int id, [FromBody] Tickets tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tickets.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(tickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(id))
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

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> PostTickets([FromBody] Tickets tickets)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tickets.Add(tickets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTickets", new { id = tickets.TicketId }, tickets);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tickets = await _context.Tickets.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(tickets);
            await _context.SaveChangesAsync();

            return Ok(tickets);
        }

        private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}