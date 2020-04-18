using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IService<Doctor> _service;

        public DoctorController(IService<Doctor> service)
        {
            _service = service;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
            return _service.GetAll();
        }

        // GET: api/Lekar/guid
        [HttpGet("{guid}")]
        public ActionResult<Doctor> GetDoctor(string guid)
        {
            var doctor = _service.GetByGuid(guid);
            if (doctor == null)
            {
                return NotFound();
            }
            return doctor;
        }

        //PUT: api/Lekar/guid
        [HttpPut("{guid}")]
        public IActionResult PutDoctor(string guid, [FromBody]Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var doc = _service.GetByGuid(guid);
                if (doc != null)
                {
                    _service.Update(guid, doctor, doc);
                    return Accepted();
                }
                else
                {
                    doctor.Guid = guid;
                    _service.Create(doctor);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Doctor
        [HttpPost]
        public IActionResult PostDoctor([FromBody]Doctor doctor)
        {
            if (_service.GetByGuid(doctor.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(doctor);
            return CreatedAtAction("PostDoctor", new { guid = doctor.Guid }, doctor);
        }

        // DELETE: api/Doctor/guid
        [HttpDelete("{guid}")]
        public IActionResult DeleteDoctor(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
