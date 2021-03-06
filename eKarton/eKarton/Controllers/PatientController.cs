﻿using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IService<Patient> _service;

        public PatientController(IService<Patient> service)
        {
            _service = service;
        }
        // GET: api/Patient
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return _service.GetAll();
        }

        // GET: api/Patient/guid
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

        // PUT: api/Patient/guid
        [HttpPut("{guid}")]
        public IActionResult PutPatient(string guid, [FromBody]Patient patient)
        {
            if (ModelState.IsValid)
            {
                var _patient = _service.GetByGuid(guid);
                if (_patient != null)
                {
                    _service.Update(guid, patient, _patient);
                    return Accepted();
                }
                else
                {
                    patient.Guid = guid;
                    _service.Create(patient);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Patient
        [HttpPost]
        public ActionResult<Patient> PostPatient([FromBody]Patient patient)
        {
            if (_service.GetByGuid(patient.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(patient);
            return CreatedAtAction("PostPatient", new { guid = patient.Guid }, patient);
        }

        // DELETE: api/Patient/guid
        [HttpDelete("{guid}")]
        public ActionResult<Patient> DeletePatient(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
