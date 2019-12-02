using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKarton.Models.SQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eKarton.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OsobaController : ControllerBase
    {
        private readonly EKartonContext _context;

        public OsobaController(EKartonContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Osoba>>> GetOsobe()
        {
            return await _context.OsobeLista.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Osoba>> GetOsoba(int id)
        {
            var osoba = await _context.OsobeLista.FindAsync(id);

            if (osoba == null)
            {
                return NotFound();
            }

            return osoba;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba(int id, Osoba osoba)
        {
            if (id != osoba.OsobaID)
            {
                return BadRequest();
            }

            _context.Entry(osoba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsobaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<EKarton>> PostEKarton(Osoba osoba)
        {
            _context.OsobeLista.Add(osoba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOsoba", new { id = osoba.OsobaID }, osoba);
        }

        // DELETE: api/EKarton/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Osoba>> DeleteOsoba(int id)
        {
            var osoba = await _context.OsobeLista.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }

            _context.OsobeLista.Remove(osoba);
            await _context.SaveChangesAsync();

            return osoba;
        }

        private bool OsobaExists(int id)
        {
            return _context.OsobeLista.Any(e => e.OsobaID == id);
        }
    }
}
