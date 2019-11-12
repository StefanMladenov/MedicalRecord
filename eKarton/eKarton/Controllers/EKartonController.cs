using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eKarton.Models.SQL;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EKartonController : ControllerBase
    {
        private readonly EKartonContext _context;

        public EKartonController(EKartonContext context)
        {
            _context = context;
        }

        // GET: api/EKarton
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EKarton>>> GetEKartoniLista()
        {
            return await _context.EKartoniLista.ToListAsync();
        }

        // GET: api/EKarton/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EKarton>> GetEKarton(int id)
        {
            var eKarton = await _context.EKartoniLista.FindAsync(id);

            if (eKarton == null)
            {
                return NotFound();
            }

            return eKarton;
        }

        // PUT: api/EKarton/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEKarton(int id, EKarton eKarton)
        {
            if (id != eKarton.KartonID)
            {
                return BadRequest();
            }

            _context.Entry(eKarton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EKartonExists(id))
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

        // POST: api/EKarton
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<EKarton>> PostEKarton(EKarton eKarton)
        {
            _context.EKartoniLista.Add(eKarton);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEKarton", new { id = eKarton.KartonID }, eKarton);
        }

        // DELETE: api/EKarton/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EKarton>> DeleteEKarton(int id)
        {
            var eKarton = await _context.EKartoniLista.FindAsync(id);
            if (eKarton == null)
            {
                return NotFound();
            }

            _context.EKartoniLista.Remove(eKarton);
            await _context.SaveChangesAsync();

            return eKarton;
        }

        private bool EKartonExists(int id)
        {
            return _context.EKartoniLista.Any(e => e.KartonID == id);
        }
    }
}
