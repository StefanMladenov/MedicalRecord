
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationStatusController : ControllerBase
    {
        private readonly VaccinationStatusService _service;
        public VaccinationStatusController(MedicalRecordContext context)
        {
            _service = new VaccinationStatusService(context);
        }

        // GET: api/VaccinationStatus
        [HttpGet]
        public ActionResult<IEnumerable<VaccinationStatus>> GetVaccinationStatuses()
        {
            return _service.GetVaccinationStatuses();
        }

        // GET: api/VaccinationStatus/5
        [HttpGet("{id}")]
        public ActionResult<VaccinationStatus> GetVaccinationStatus(int id)
        {
            var vaccinationStatus = _service.GetVaccinationStatus(id);

            if (vaccinationStatus == null)
            {
                return NotFound();
            }

            return vaccinationStatus;
        }

        // PUT: api/VaccinationStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutVaccinationStatus(int id, [FromBody]VaccinationStatus vaccinationStatus)
        {
            _service.PutVaccinationStatus(id, vaccinationStatus);
            return NoContent();
        }

        // POST: api/VaccinationStatus
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<VaccinationStatus> PostVaccinationStatus([FromBody]VaccinationStatus vaccinationStatus)
        {
            _service.PostVaccinationStatus(vaccinationStatus);
            return CreatedAtAction("GetVaccinationStatus", new { id = vaccinationStatus.Id }, vaccinationStatus);
        }

        // DELETE: api/VaccinationStatus/5
        [HttpDelete("{id}")]
        public ActionResult<VaccinationStatus> DeleteVaccinationStatus(int id)
        {
            _service.DeleteVaccinationStatus(id);
            return Accepted();
        } 
    }
}
