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
        private readonly IService<VaccinationStatus> _service;
        public VaccinationStatusController(MedicalRecordContext context)
        {
            _service = new VaccinationStatusService(context);
        }

        // GET: api/VaccinationStatus
        [HttpGet]
        public ActionResult<IEnumerable<VaccinationStatus>> GetVaccinationStatuses()
        {
            return _service.GetAll();
        }

        // GET: api/VaccinationStatus/5
        [HttpGet("{guid}")]
        public ActionResult<VaccinationStatus> GetVaccinationStatus(string guid)
        {
            var vaccinationStatus = _service.GetByGuid(guid);

            if (vaccinationStatus == null)
            {
                return NotFound();
            }

            return vaccinationStatus;
        }

        // PUT: api/VaccinationStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public IActionResult PutVaccinationStatus(string guid, [FromBody]VaccinationStatus vaccinationStatus)
        {
            _service.Update(guid, vaccinationStatus);
            return NoContent();
        }

        // POST: api/VaccinationStatus
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<VaccinationStatus> PostVaccinationStatus([FromBody]VaccinationStatus vaccinationStatus)
        {
            _service.Create(vaccinationStatus);
            return CreatedAtAction("GetVaccinationStatus", new { guid = vaccinationStatus.Guid }, vaccinationStatus);
        }

        // DELETE: api/VaccinationStatus/5
        [HttpDelete("{guid}")]
        public ActionResult<VaccinationStatus> DeleteVaccinationStatus(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        } 
    }
}
