using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IService<Doctor> _service;

        public DoctorController(MedicalRecordContext context)
        {
            _service = new DoctorService(context);
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
            return _service.GetAll();
        }

        // GET: api/Lekar/5
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

        //PUT: api/Lekar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public IActionResult PutDoctor(string guid, [FromBody]Doctor doctor)
        {
            if (guid != doctor.Guid)
            {
                return BadRequest();
            }
            _service.Update(guid, doctor);
            return Accepted();
        }

        [HttpPost]
        public IActionResult PostDoctor([FromBody]Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _service.Create(doctor);
                return Accepted();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{guid}")]
        public IActionResult DeleteDoctor(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
