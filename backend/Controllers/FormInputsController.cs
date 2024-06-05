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
    public class FormInputsController : ControllerBase
    {
        private readonly backendContext _context;

        public FormInputsController(backendContext context)
        {
            _context = context;
        }

        // GET: api/FormInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormInputs>>> GetFormInputs()
        {
            return await _context.FormInputs.ToListAsync();
        }

        // GET: api/FormInputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormInputs>> GetFormInputs(int id)
        {
            var formInputs = await _context.FormInputs.FindAsync(id);

            if (formInputs == null)
            {
                return NotFound();
            }

            return formInputs;
        }

        // PUT: api/FormInputs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormInputs(int id, FormInputs formInputs)
        {
            if (id != formInputs.Id)
            {
                return BadRequest();
            }

            _context.Entry(formInputs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormInputsExists(id))
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

        // POST: api/FormInputs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormInputs>> PostFormInputs(FormInputs formInputs)
        {
            _context.FormInputs.Add(formInputs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormInputs", new { id = formInputs.Id }, formInputs);
        }

        // DELETE: api/FormInputs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormInputs(int id)
        {
            var formInputs = await _context.FormInputs.FindAsync(id);
            if (formInputs == null)
            {
                return NotFound();
            }

            _context.FormInputs.Remove(formInputs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormInputsExists(int id)
        {
            return _context.FormInputs.Any(e => e.Id == id);
        }
    }
}
