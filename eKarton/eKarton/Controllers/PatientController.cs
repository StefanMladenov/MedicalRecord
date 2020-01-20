using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return _service.GetPatients();
        }

        // GET: api/Pacijent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
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
        public async Task<IActionResult> PutPatient(int id, [FromBody]Patient patient)
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
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _service.PostPatient(patient);
            //_context.SaveChangesAsync();
            return Accepted();
            //return CreatedAtAction("GetPacijent", new { id = pacijent.Id }, pacijent);
        }

        // DELETE: api/Pacijent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            _service.DeletePatient(id);
            return Accepted();
        }
    }
}
