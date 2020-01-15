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
    public class LekarController : ControllerBase
    {
        private readonly LekarServis _servis;

        public LekarController(EKartonContext context)
        {
            _servis = new LekarServis(context);
        }

        // GET: api/Lekar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lekar>>> GetLekari()
        {
            return _servis.GetLekari();
        }

        // GET: api/Lekar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lekar>> GetLekar(int id)
        {
            var lekar = _servis.GetLekar(id);

            if (lekar == null)
            {
                return NotFound();
            }

            return lekar;
        }

        //PUT: api/Lekar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLekar(int id, [FromBody]Lekar lekar)
        {
            if (id != lekar.Id)
            {
                return BadRequest();
            }

            _servis.PutLekar(id, lekar);
            //_context.Entry(lekar).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!LekarExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return Accepted();
            //return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostLekar([FromBody]Lekar lekar)
        {
            Lekar _lekar = new Lekar();
            _lekar.Ime = lekar.Ime;
            _lekar.Prezime = lekar.Prezime;
            _servis.PostLekar(_lekar);
            return Accepted();
        }
        //// POST: api/Lekar
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Lekar>> PostLekar(Lekar lekar)
        //{
        //    _context.Lekari.Add(lekar);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLekar", new { id = lekar.Id }, lekar);
        //}

        //// DELETE: api/Lekar/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Lekar>> DeleteLekar(int id)
        //{
        //    var lekar = await _context.Lekari.FindAsync(id);
        //    if (lekar == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Lekari.Remove(lekar);
        //    await _context.SaveChangesAsync();

        //    return lekar;
        //}

        //private bool LekarExists(int id)
        //{
        //    return _context.Lekari.Any(e => e.Id == id);
        //}
    }
}
