using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IService<MedicalRecord> _service;
        public MedicalRecordController(IService<MedicalRecord> service)
        {
            _service = service;
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
            var medicalRecord = _service.GetByGuid(guid);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return medicalRecord;
        }

        // PUT: api/MedicalRecord/guid
        [HttpPut("{guid}")]
        public ActionResult<MedicalRecord> PutMedicalRecord(string guid, [FromBody]MedicalRecord medicalRecord)
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
            return CreatedAtAction("PostMedicalRecord", new { guid = medicalRecord.Guid }, medicalRecord);
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
