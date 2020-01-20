using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorController(MedicalRecordContext context)
        {
            _service = new DoctorService(context);
        }

        // GET: api/Lekar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return _service.GetDoctors();
        }

        // GET: api/Lekar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = _service.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return doctor;
        }

        //PUT: api/Lekar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, [FromBody]Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }
            _service.PutDoctor(id, doctor);
            return Accepted();
        }
        [HttpPost]
        public async Task<IActionResult> PostDoctor([FromBody]Doctor doctor)
        {
            _service.PostDoctor(doctor);
            return Accepted(); 
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            _service.DeleteDoctor(id);
            return Accepted();
        }
    }
}
