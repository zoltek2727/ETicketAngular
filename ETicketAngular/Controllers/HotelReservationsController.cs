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
    public class HotelReservationsController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public HotelReservationsController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/HotelReservations
        [HttpGet]
        public IEnumerable<HotelReservations> GetHotelReservations()
        {
            return _context.HotelReservations;
        }

        // GET: api/HotelReservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelReservations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelReservations = await _context.HotelReservations.FindAsync(id);

            if (hotelReservations == null)
            {
                return NotFound();
            }

            return Ok(hotelReservations);
        }

        // PUT: api/HotelReservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelReservations([FromRoute] int id, [FromBody] HotelReservations hotelReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotelReservations.HotelReservationId)
            {
                return BadRequest();
            }

            _context.Entry(hotelReservations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelReservationsExists(id))
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

        // POST: api/HotelReservations
        [HttpPost]
        public async Task<IActionResult> PostHotelReservations([FromBody] HotelReservations hotelReservations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HotelReservations.Add(hotelReservations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelReservations", new { id = hotelReservations.HotelReservationId }, hotelReservations);
        }

        // DELETE: api/HotelReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelReservations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotelReservations = await _context.HotelReservations.FindAsync(id);
            if (hotelReservations == null)
            {
                return NotFound();
            }

            _context.HotelReservations.Remove(hotelReservations);
            await _context.SaveChangesAsync();

            return Ok(hotelReservations);
        }

        private bool HotelReservationsExists(int id)
        {
            return _context.HotelReservations.Any(e => e.HotelReservationId == id);
        }
    }
}