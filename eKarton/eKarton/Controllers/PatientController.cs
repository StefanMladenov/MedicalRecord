using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientController(MedicalRecordContext context)
        {
            _service = new PatientService(context);
        }
        // GET: api/Pacijent
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return _service.GetPatients();
        }

        // GET: api/Pacijent/5
        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatient(int id)
        {
            var patient = _service.GetPatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }

        // PUT: api/Pacijent/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutPatient(int id, [FromBody]Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }
            _service.PutPatient(id, patient);
            return Accepted();
        }

        // POST: api/Pacijent
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Patient> PostPatient([FromBody]Patient patient)
        {
            _service.PostPatient(patient);
            return Accepted();;
        }

        // DELETE: api/Pacijent/5
        [HttpDelete("{id}")]
        public ActionResult<Patient> DeletePatient(int id)
        {
            _service.DeletePatient(id);
            return Accepted();
        }
    }
}
