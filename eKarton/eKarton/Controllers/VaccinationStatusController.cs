﻿using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinationStatusController : ControllerBase
    {
        private readonly IService<VaccinationStatus> _service;

        public VaccinationStatusController(IService<VaccinationStatus> service)
        {
            _service = service;
        }

        // GET: api/VaccinationStatus
        [HttpGet]
        public ActionResult<IEnumerable<VaccinationStatus>> GetVaccinationStatuses()
        {
            return _service.GetAll();
        }

        // GET: api/VaccinationStatus/guid
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

        // PUT: api/VaccinationStatus/guid
        [HttpPut("{guid}")]
        public IActionResult PutVaccinationStatus(string guid, [FromBody]VaccinationStatus vaccinationStatus)
        {
            if (ModelState.IsValid)
            {
                var vaccStatus = _service.GetByGuid(guid);
                if (vaccStatus != null)
                {
                    _service.Update(guid, vaccinationStatus, vaccStatus);
                    return Accepted();
                }
                else
                {
                    vaccinationStatus.Guid = guid;
                    _service.Create(vaccinationStatus);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/VaccinationStatus
        [HttpPost]
        public ActionResult<VaccinationStatus> PostVaccinationStatus([FromBody]VaccinationStatus vaccinationStatus)
        {
            if (_service.GetByGuid(vaccinationStatus.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(vaccinationStatus);
            return CreatedAtAction("PostVaccinationStatus", new { guid = vaccinationStatus.Guid }, vaccinationStatus);
        }

        // DELETE: api/VaccinationStatus/guid
        [HttpDelete("{guid}")]
        public ActionResult<VaccinationStatus> DeleteVaccinationStatus(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
