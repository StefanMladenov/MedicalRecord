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
    public class BolestController : ControllerBase
    {
        private readonly EKartonContext _context;

        public BolestController(EKartonContext context)
        {
            _context = context;
        }

        // GET: api/Bolest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bolest>>> GetBolesti()
        {
            return await _context.Bolesti.ToListAsync();
        }

        // GET: api/Bolest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bolest>> GetBolest(int id)
        {
            var bolest = await _context.Bolesti.FindAsync(id);

            if (bolest == null)
            {
                return NotFound();
            }

            return bolest;
        }

        // PUT: api/Bolest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolest(int id, Bolest bolest)
        {
            if (id != bolest.Id)
            {
                return BadRequest();
            }

            _context.Entry(bolest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BolestExists(id))
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

        // POST: api/Bolest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bolest>> PostBolest(Bolest bolest)
        {
            _context.Bolesti.Add(bolest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBolest", new { id = bolest.Id }, bolest);
        }

        // DELETE: api/Bolest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bolest>> DeleteBolest(int id)
        {
            var bolest = await _context.Bolesti.FindAsync(id);
            if (bolest == null)
            {
                return NotFound();
            }

            _context.Bolesti.Remove(bolest);
            await _context.SaveChangesAsync();

            return bolest;
        }

        private bool BolestExists(int id)
        {
            return _context.Bolesti.Any(e => e.Id == id);
        }
    }
}
