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
    public class PurchasesController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public PurchasesController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public IEnumerable<Purchases> GetPurchases()
        {
            return _context.Purchases;
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchases([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchases = await _context.Purchases.FindAsync(id);

            if (purchases == null)
            {
                return NotFound();
            }

            return Ok(purchases);
        }

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchases([FromRoute] int id, [FromBody] Purchases purchases)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != purchases.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasesExists(id))
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

        // POST: api/Purchases
        [HttpPost]
        public async Task<IActionResult> PostPurchases([FromBody] Purchases purchases)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Purchases.Add(purchases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchases", new { id = purchases.PurchaseId }, purchases);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchases([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchases = await _context.Purchases.FindAsync(id);
            if (purchases == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchases);
            await _context.SaveChangesAsync();

            return Ok(purchases);
        }

        private bool PurchasesExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseId == id);
        }
    }
}