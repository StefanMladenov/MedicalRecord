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
        private readonly IService<Patient> _service;

        public PatientController(MedicalRecordContext context)
        {
            _service = new PatientService(context);
        }
        // GET: api/Pacijent
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return _service.GetAll();
        }

        // GET: api/Pacijent/5
        [HttpGet("{guid}")]
        public ActionResult<Patient> GetPatient(string guid)
        {
            var patient = _service.GetByGuid(guid);
            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }

        // PUT: api/Patient/5
        [HttpPut("{guid}")]
        public IActionResult PutPatient(string guid, [FromBody]Patient patient)
        {
            if (guid != patient.Guid)
            {
                return BadRequest();
            }
            _service.Update(guid, patient);
            return Accepted();
        }

        // POST: api/Patient
        [HttpPost]
        public ActionResult<Patient> PostPatient([FromBody]Patient patient)
        {
            if (ModelState.IsValid)
            {
                _service.Create(patient);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Patient/5
        [HttpDelete("{guid}")]
        public ActionResult<Patient> DeletePatient(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }

/*        [HttpPost("{UCIN}")]
        public ActionResult PatientExists(string ucin)
        {
            bool exists = _service.Exists(ucin);
            if(exists)
            {
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }*/
    }
}
