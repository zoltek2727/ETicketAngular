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
    public class DeliveriesController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public DeliveriesController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Deliveries
        [HttpGet]
        public IEnumerable<Deliveries> GetDeliveries()
        {
            return _context.Deliveries;
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveries = await _context.Deliveries.FindAsync(id);

            if (deliveries == null)
            {
                return NotFound();
            }

            return Ok(deliveries);
        }

        // PUT: api/Deliveries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveries([FromRoute] int id, [FromBody] Deliveries deliveries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveries.DeliveryId)
            {
                return BadRequest();
            }

            _context.Entry(deliveries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveriesExists(id))
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

        // POST: api/Deliveries
        [HttpPost]
        public async Task<IActionResult> PostDeliveries([FromBody] Deliveries deliveries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Deliveries.Add(deliveries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveries", new { id = deliveries.DeliveryId }, deliveries);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveries = await _context.Deliveries.FindAsync(id);
            if (deliveries == null)
            {
                return NotFound();
            }

            _context.Deliveries.Remove(deliveries);
            await _context.SaveChangesAsync();

            return Ok(deliveries);
        }

        private bool DeliveriesExists(int id)
        {
            return _context.Deliveries.Any(e => e.DeliveryId == id);
        }
    }
}