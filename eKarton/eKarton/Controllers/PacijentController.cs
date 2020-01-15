using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PacijentController : ControllerBase
    {
        private readonly EKartonContext _context;
        private readonly PacijentServis _servis;

        public PacijentController(EKartonContext context)
        {
            _context = context;
        }

        // GET: api/Pacijent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacijent>>> GetPacijenti()
        {
            return await _context.Pacijenti.ToListAsync();
        }

        // GET: api/Pacijent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacijent>> GetPacijent(int id)
        {
            var pacijent = await _context.Pacijenti.FindAsync(id);

            if (pacijent == null)
            {
                return NotFound();
            }

            return pacijent;
        }

        // PUT: api/Pacijent/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacijent(int id, Pacijent pacijent)
        {
            if (id != pacijent.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacijent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacijentExists(id))
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

        // POST: api/Pacijent
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pacijent>> PostPacijent(Pacijent pacijent)
        {
            _context.Pacijenti.Add(pacijent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacijent", new { id = pacijent.Id }, pacijent);
        }

        // DELETE: api/Pacijent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pacijent>> DeletePacijent(int id)
        {
            var pacijent = await _context.Pacijenti.FindAsync(id);
            if (pacijent == null)
            {
                return NotFound();
            }

            _context.Pacijenti.Remove(pacijent);
            await _context.SaveChangesAsync();

            return pacijent;
        }

        private bool PacijentExists(int id)
        {
            return _context.Pacijenti.Any(e => e.Id == id);
        }
    }
}
