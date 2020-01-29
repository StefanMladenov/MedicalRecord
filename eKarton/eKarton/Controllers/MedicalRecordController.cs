using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly MedicalRecordService _service;
        public MedicalRecordController(MedicalRecordContext context)
        {
            _service = new MedicalRecordService(context);
        }

        // GET: api/EKarton
        [HttpGet]
        public ActionResult<IEnumerable<MedicalRecord>> GetMedicalRecords()
        {
            return _service.GetMedicalRecords();
        }

        // GET: api/EKarton/5
        [HttpGet("{id}")]
        public ActionResult<MedicalRecord> GetMedicalRecord(int id)
        {
            var medicalRecord =  _service.GetMedicalRecord(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return medicalRecord;
        }

        // PUT: api/EKarton/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalRecord(int id, [FromBody]MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.Id)
            {
                return BadRequest();
            }
            _service.PutMedicalRecord(id, medicalRecord);
            return NoContent();
        }

        // POST: api/EKarton
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<MedicalRecord> PostMedicalRecord([FromBody]MedicalRecord medicalRecord)
        {
            _service.PostMedicalRecord(medicalRecord);
            return CreatedAtAction("GetEKarton", new { id = medicalRecord.Id }, medicalRecord);
        }

        // DELETE: api/EKarton/5
        [HttpDelete("{id}")]
        public ActionResult<MedicalRecord> DeleteMedicalRecord(int id)
        {
            _service.DeleteMedicalRecord(id);
            return Accepted();
        }
    }
}
