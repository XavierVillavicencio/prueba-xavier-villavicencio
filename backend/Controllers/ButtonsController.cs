using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButtonsController : ControllerBase
    {
        private readonly backendContext _context;

        public ButtonsController(backendContext context)
        {
            _context = context;
        }

        // GET: api/Buttons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buttons>>> GetButtons()
        {
            return await _context.Buttons.ToListAsync();
        }

        // GET: api/Buttons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Buttons>> GetButtons(int id)
        {
            var buttons = await _context.Buttons.FindAsync(id);

            if (buttons == null)
            {
                return NotFound();
            }

            return buttons;
        }

        // PUT: api/Buttons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutButtons(int id, Buttons buttons)
        {
            if (id != buttons.Id)
            {
                return BadRequest();
            }

            _context.Entry(buttons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ButtonsExists(id))
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

        // POST: api/Buttons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Buttons>> PostButtons(Buttons buttons)
        {
            _context.Buttons.Add(buttons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetButtons", new { id = buttons.Id }, buttons);
        }

        // DELETE: api/Buttons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteButtons(int id)
        {
            var buttons = await _context.Buttons.FindAsync(id);
            if (buttons == null)
            {
                return NotFound();
            }

            _context.Buttons.Remove(buttons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ButtonsExists(int id)
        {
            return _context.Buttons.Any(e => e.Id == id);
        }
    }
}
