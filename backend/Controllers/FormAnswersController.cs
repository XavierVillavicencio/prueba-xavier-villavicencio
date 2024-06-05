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
    public class FormAnswersController : ControllerBase
    {
        private readonly backendContext _context;

        public FormAnswersController(backendContext context)
        {
            _context = context;
        }

        // GET: api/FormAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormAnswers>>> GetFormAnswers()
        {
            return await _context.FormAnswers.ToListAsync();
        }

        // GET: api/FormAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormAnswers>> GetFormAnswers(int id)
        {
            var formAnswers = await _context.FormAnswers.FindAsync(id);

            if (formAnswers == null)
            {
                return NotFound();
            }

            return formAnswers;
        }

        // PUT: api/FormAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormAnswers(int id, FormAnswers formAnswers)
        {
            if (id != formAnswers.Id)
            {
                return BadRequest();
            }

            _context.Entry(formAnswers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormAnswersExists(id))
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

        // POST: api/FormAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormAnswers>> PostFormAnswers(FormAnswers formAnswers)
        {
            _context.FormAnswers.Add(formAnswers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormAnswers", new { id = formAnswers.Id }, formAnswers);
        }

        // DELETE: api/FormAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormAnswers(int id)
        {
            var formAnswers = await _context.FormAnswers.FindAsync(id);
            if (formAnswers == null)
            {
                return NotFound();
            }

            _context.FormAnswers.Remove(formAnswers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormAnswersExists(int id)
        {
            return _context.FormAnswers.Any(e => e.Id == id);
        }
    }
}
