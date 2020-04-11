using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eMedicalRecord.Models.SQL;
using eMedicalRecord.Services;

namespace eMedicalRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IService<Allergy> _service;

        public AllergyController(MedicalRecordContext context)
        {
            _service = new AllergyService(context);
        }

        // GET: api/Allergy
        [HttpGet]
        public ActionResult<IEnumerable<Allergy>> GetAllergies()
        {
            return _service.GetAll();
        }

        // GET: api/Allergy/guid
        [HttpGet("{guid}")]
        public ActionResult<Allergy> GetAllergy(string guid)
        {
            var allergy = _service.GetByGuid(guid);
            if (allergy == null)
            {
                return NotFound();
            }
            return allergy;
        }

        // PUT: api/Allergy/guid
        [HttpPut("{guid}")]
        public ActionResult<Allergy> PutAllergy(string guid, [FromBody]Allergy allergy)
        {
            if (ModelState.IsValid) 
            {
                var _allergy = _service.GetByGuid(guid);
                if (_allergy != null)
                {
                    _service.Update(guid, allergy, _allergy);
                    return Accepted();
                }
                else
                {
                    allergy.Guid = guid;
                    _service.Create(allergy);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Allergy
        [HttpPost]
        public ActionResult<Allergy> PostAllergy([FromBody]Allergy allergy)
        {
            if(_service.GetByGuid(allergy.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(allergy);
            return CreatedAtAction("PostAllergy", new { guid = allergy.Guid }, allergy);
        }

        // DELETE: api/Allergy/guid
        [HttpDelete("{guid}")]
        public ActionResult<Allergy> DeleteAllergy(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
