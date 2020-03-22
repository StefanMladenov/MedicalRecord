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
        private readonly IService<MedicalRecord> _service;
        public MedicalRecordController(MedicalRecordContext context)
        {
            _service = new MedicalRecordService(context);
        }

        // GET: api/EKarton
        [HttpGet]
        public ActionResult<IEnumerable<MedicalRecord>> GetMedicalRecords()
        {
            return _service.GetAll();
        }

        // GET: api/EKarton/5
        [HttpGet("{guid}")]
        public ActionResult<MedicalRecord> GetMedicalRecord(string guid)
        {
            var medicalRecord =  _service.GetByGuid(guid);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return medicalRecord;
        }

        // PUT: api/EKarton/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutMedicalRecord(string guid, [FromBody]MedicalRecord medicalRecord)
        {
            if (guid != medicalRecord.Guid)
            {
                return BadRequest();
            }
            _service.Update(guid, medicalRecord);
            return NoContent();
        }

        // POST: api/EKarton
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<MedicalRecord> PostMedicalRecord([FromBody]MedicalRecord medicalRecord)
        {
            _service.Create(medicalRecord);
            //return CreatedAtAction("GetEKarton", new { guid = medicalRecord.Guid }, medicalRecord);
            return Accepted();
        }

        // DELETE: api/EKarton/5
        [HttpDelete("{guid}")]
        public ActionResult<MedicalRecord> DeleteMedicalRecord(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
