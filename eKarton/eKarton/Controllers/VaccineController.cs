﻿using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IService<Vaccine> _service;

        public VaccineController(IService<Vaccine> service)
        {
            _service = service;
        }

        // GET: api/Vaccine
        [HttpGet]
        public ActionResult<IEnumerable<Vaccine>> GetVaccines()
        {
            return _service.GetAll();
        }

        // GET: api/Vaccine/guid
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

        // PUT: api/Vaccine/guid
        [HttpPut("{guid}")]
        public IActionResult PutVaccine(string guid, [FromBody]Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                var vacc = _service.GetByGuid(guid);
                if (vacc != null)
                {
                    _service.Update(guid, vaccine, vacc);
                    return Accepted();
                }
                else
                {
                    vaccine.Guid = guid;
                    _service.Create(vaccine);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Vaccine
        [HttpPost]
        public ActionResult<Vaccine> PostVaccine([FromBody]Vaccine vaccine)
        {
            if (_service.GetByGuid(vaccine.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(vaccine);
            return CreatedAtAction("PostVaccine", new { guid = vaccine.Guid }, vaccine);
        }

        // DELETE: api/Vaccine/guid
        [HttpDelete("{guid}")]
        public ActionResult<Vaccine> DeleteVaccine(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
