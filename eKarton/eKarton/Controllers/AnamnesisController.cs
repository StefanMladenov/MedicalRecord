using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnamnesisController : ControllerBase
    {
        private readonly AnamnesisService _service;

        public AnamnesisController(MedicalRecordContext context)
        {
            _service = new AnamnesisService(context);
        }

        // GET: api/Anamnesis
        [HttpGet]
        public ActionResult<IEnumerable<Anamnesis>> GetAnamnesies()
        {
            return  _service.GetAnamnesies();
        }

        // GET: api/Anamnesis/5
        [HttpGet("{id}")]
        public ActionResult<Anamnesis> GetAnamnesis(int id)
        {
            var anamnesis = _service.GetAnamnesis(id);
            if (anamnesis == null)
            {
                return NotFound();
            }
            return anamnesis;
        }

        // PUT: api/Anamnesis/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutAnamnesis(int id, [FromBody] Anamnesis anamnesis)
        {
            if (id != anamnesis.Id)
            {
                return BadRequest();
            }
            _service.PutAnamnesis(id, anamnesis);
            return NoContent();
        }

        // POST: api/Anamnesis
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Anamnesis> PostAnamnesis([FromBody]Anamnesis anamnesis)
        {
            _service.PostAnamnesis(anamnesis);

            return CreatedAtAction("GetAnamnesis", new { id = anamnesis.Id }, anamnesis);
        }

        // DELETE: api/Anamnesis/5
        [HttpDelete("{id}")]
        public ActionResult<Anamnesis> DeleteAnamnesis(int id)
        {
            _service.DeleteAnamnesis(id);
            return Accepted();
        }
    }
}
