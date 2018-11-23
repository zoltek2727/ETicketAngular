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
    public class TransportReservationsController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public TransportReservationsController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/TransportReservations
        [HttpGet]
        public IEnumerable<TransportReservations> GetTransportReservations()
        {
            return _context.TransportReservations;
        }

        // GET: api/TransportReservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransportReservations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportReservations = await _context.TransportReservations.FindAsync(id);

            if (transportReservations == null)
            {
                return NotFound();
            }

            return Ok(transportReservations);
        }

        // PUT: api/TransportReservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportReservations([FromRoute] int id, [FromBody] TransportReservations transportReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportReservations.TransportReservationId)
            {
                return BadRequest();
            }

            _context.Entry(transportReservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportReservationsExists(id))
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

        // POST: api/TransportReservations
        [HttpPost]
        public async Task<IActionResult> PostTransportReservations([FromBody] TransportReservations transportReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TransportReservations.Add(transportReservations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransportReservations", new { id = transportReservations.TransportReservationId }, transportReservations);
        }

        // DELETE: api/TransportReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportReservations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportReservations = await _context.TransportReservations.FindAsync(id);
            if (transportReservations == null)
            {
                return NotFound();
            }

            _context.TransportReservations.Remove(transportReservations);
            await _context.SaveChangesAsync();

            return Ok(transportReservations);
        }

        private bool TransportReservationsExists(int id)
        {
            return _context.TransportReservations.Any(e => e.TransportReservationId == id);
        }
    }
}