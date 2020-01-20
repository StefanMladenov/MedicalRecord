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
    public class DiseaseController : ControllerBase
    {
        private readonly MedicalRecordContext _context;

        public DiseaseController(MedicalRecordContext context)
        {
            _context = context;
        }

        // GET: api/Bolest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetBolesti()
        {
            return await _context.Diseases.ToListAsync();
        }

        // GET: api/Bolest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetBolest(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);

            if (disease == null)
            {
                return NotFound();
            }

            return disease;
        }

        // PUT: api/Bolest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBolest(int id, Disease disease)
        {
            if (id != disease.Id)
            {
                return BadRequest();
            }

            _context.Entry(disease).State = EntityState.Modified;

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
        public async Task<ActionResult<Disease>> PostBolest(Disease disease)
        {
            _context.Diseases.Add(disease);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBolest", new { id = disease.Id }, disease);
        }

        // DELETE: api/Bolest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Disease>> DeleteBolest(int id)
        {
            var disease = await _context.Diseases.FindAsync(id);
            if (disease == null)
            {
                return NotFound();
            }

            _context.Diseases.Remove(disease);
            await _context.SaveChangesAsync();

            return disease;
        }

        private bool BolestExists(int id)
        {
            return _context.Diseases.Any(e => e.Id == id);
        }
    }
}
