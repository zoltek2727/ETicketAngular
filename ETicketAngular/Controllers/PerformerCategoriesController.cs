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
    public class PerformerCategoriesController : ControllerBase
    {
        private readonly ETicketDBContext _context;

        public PerformerCategoriesController(ETicketDBContext context)
        {
            _context = context;
        }

        // GET: api/PerformerCategories
        [HttpGet]
        public IEnumerable<PerformerCategories> GetPerformerCategories()
        {
            return _context.PerformerCategories;
        }

        // GET: api/PerformerCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformerCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var performerCategories = await _context.PerformerCategories.FindAsync(id);

            if (performerCategories == null)
            {
                return NotFound();
            }

            return Ok(performerCategories);
        }

        // PUT: api/PerformerCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformerCategories([FromRoute] int id, [FromBody] PerformerCategories performerCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != performerCategories.PerformerCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(performerCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerCategoriesExists(id))
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

        // POST: api/PerformerCategories
        [HttpPost]
        public async Task<IActionResult> PostPerformerCategories([FromBody] PerformerCategories performerCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PerformerCategories.Add(performerCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformerCategories", new { id = performerCategories.PerformerCategoryId }, performerCategories);
        }

        // DELETE: api/PerformerCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformerCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var performerCategories = await _context.PerformerCategories.FindAsync(id);
            if (performerCategories == null)
            {
                return NotFound();
            }

            _context.PerformerCategories.Remove(performerCategories);
            await _context.SaveChangesAsync();

            return Ok(performerCategories);
        }

        private bool PerformerCategoriesExists(int id)
        {
            return _context.PerformerCategories.Any(e => e.PerformerCategoryId == id);
        }
    }
}