using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly VaccineService _service;
        public VaccineController(MedicalRecordContext context)
        {
            _service = new VaccineService(context);
        }

        // GET: api/Vaccine
        [HttpGet]
        public ActionResult<IEnumerable<Vaccine>> GetVaccines()
        {
            return _service.GetVaccines();
        }

        // GET: api/Vaccine/5
        [HttpGet("{id}")]
        public ActionResult<Vaccine> GetVaccine(int id)
        {
            var vaccine = _service.GetVaccine(id);

            if (vaccine == null)
            {
                return NotFound();
            }

            return vaccine;
        }

        // PUT: api/Vaccine/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutVaccine(int id, [FromBody]Vaccine vaccine)
        {
            _service.PutVaccine(id, vaccine);
            return NoContent();
        }

        // POST: api/Vaccine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Vaccine> PostVaccine([FromBody]Vaccine vaccine)
        {
            _service.PostVaccine(vaccine);

            return CreatedAtAction("GetVaccine", new { id = vaccine.Id }, vaccine);
        }

        // DELETE: api/Vaccine/5
        [HttpDelete("{id}")]
        public ActionResult<Vaccine> DeleteVaccine(int id)
        {
            _service.DeleteVaccine(id);
            return Accepted();
        }
    }
}
