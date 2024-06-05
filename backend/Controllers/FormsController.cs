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
    public class FormsController : ControllerBase
    {
        private readonly backendContext _context;

        public FormsController(backendContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Forms>>> GetForms()
        {
            return await _context.Forms.ToListAsync();
        }

        // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Forms>> GetForms(int id)
        {
            var forms = await _context.Forms.FindAsync(id);

            if (forms == null)
            {
                return NotFound();
            }

            return forms;
        }

        // PUT: api/Forms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForms(int id, Forms forms)
        {
            if (id != forms.Id)
            {
                return BadRequest();
            }

            _context.Entry(forms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormsExists(id))
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

        // POST: api/Forms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Forms>> PostForms(Forms forms)
        {
            _context.Forms.Add(forms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForms", new { id = forms.Id }, forms);
        }

        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForms(int id)
        {
            var forms = await _context.Forms.FindAsync(id);
            if (forms == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(forms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormsExists(int id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
