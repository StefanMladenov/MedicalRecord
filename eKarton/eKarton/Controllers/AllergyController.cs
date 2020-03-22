using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
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

        [HttpGet("ByCondition")]
        public ActionResult<List<Allergy>> GetByCondition([FromBody] Allergy allergy)
        {
            var allergiesFromGuid = _service.GetByCondition(allergy);
            if (allergiesFromGuid != null)
            {
                return allergiesFromGuid;
            }
            return NotFound();
        }

        // PUT: api/Allergy/guid
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public ActionResult<Allergy> PutAllergy(string guid, [FromBody]Allergy allergy)
        {
            if (_service.GetByGuid(guid) != null)
            {
                _service.Update(guid, allergy);
                return Accepted();
            }
            else
            {
                allergy.Guid = guid;
                _service.Create(allergy);
                return Created("guid", guid);
            }
        }

        // POST: api/Allergy
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Allergy> PostAllergy([FromBody]Allergy allergy)
        {
            if(_service.GetByGuid(allergy.Guid) != null)
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
