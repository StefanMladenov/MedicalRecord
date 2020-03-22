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
        private readonly IService<Vaccine> _service;
        public VaccineController(MedicalRecordContext context)
        {
            _service = new VaccineService(context);
        }

        // GET: api/Vaccine
        [HttpGet]
        public ActionResult<IEnumerable<Vaccine>> GetVaccines()
        {
            return _service.GetAll();
        }

        // GET: api/Vaccine/5
        [HttpGet("{guid}")]
        public ActionResult<Vaccine> GetVaccine(string guid)
        {
            var vaccine = _service.GetByGuid(guid);

            if (vaccine == null)
            {
                return NotFound();
            }

            return vaccine;
        }

        // PUT: api/Vaccine/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public IActionResult PutVaccine(string guid, [FromBody]Vaccine vaccine)
        {
            _service.Update(guid, vaccine);
            return NoContent();
        }

        // POST: api/Vaccine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Vaccine> PostVaccine([FromBody]Vaccine vaccine)
        {
            _service.Create(vaccine);

            return CreatedAtAction("GetVaccine", new { guid = vaccine.Guid }, vaccine);
        }

        // DELETE: api/Vaccine/5
        [HttpDelete("{guid}")]
        public ActionResult<Vaccine> DeleteVaccine(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
