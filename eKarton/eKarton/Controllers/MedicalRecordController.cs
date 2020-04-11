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

        // GET: api/MedicalRecord
        [HttpGet]
        public ActionResult<IEnumerable<MedicalRecord>> GetMedicalRecords()
        {
            return _service.GetAll();
        }

        // GET: api/MedicalRecord/guid
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

        // PUT: api/MedicalRecord/guid
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutMedicalRecord(string guid, [FromBody]MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                var medRec = _service.GetByGuid(guid);
                if (medRec != null)
                {
                    _service.Update(guid, medicalRecord, medRec);
                    return Accepted();
                }
                else
                {
                    medicalRecord.Guid = guid;
                    _service.Create(medicalRecord);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/MedicalRecord
        [HttpPost]
        public ActionResult<MedicalRecord> PostMedicalRecord([FromBody]MedicalRecord medicalRecord)
        {
            if (_service.GetByGuid(medicalRecord.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(medicalRecord);
            return CreatedAtAction("PostAllergy", new { guid = medicalRecord.Guid }, medicalRecord);
        }

        // DELETE: api/MedicalRecord/guid
        [HttpDelete("{guid}")]
        public ActionResult<MedicalRecord> DeleteMedicalRecord(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
