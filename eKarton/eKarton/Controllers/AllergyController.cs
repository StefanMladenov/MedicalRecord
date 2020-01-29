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
        private readonly AllergyService _service;

        public AllergyController(MedicalRecordContext context)
        {
            _service = new AllergyService(context);
        }

        // GET: api/Bolest
        [HttpGet]
        public ActionResult<IEnumerable<Allergy>> GetAllergies()
        {
            return _service.GetAllergies();
        }

        // GET: api/Bolest/5
        [HttpGet("{id}")]
        public ActionResult<Allergy> GetAllergy(int id)
        {
            var allergy = _service.GetAllergy(id);
            if (allergy == null)
            {
                return NotFound();
            }

            return allergy;
        }

        // PUT: api/Bolest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public ActionResult<Allergy> PutAllergy(int id, [FromBody]Allergy allergy)
        {
            if (id != allergy.Id)
            {
                return BadRequest();
            }
            _service.PutAllergy(id, allergy);
            return NoContent();
        }

        // POST: api/Bolest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Allergy> PostAllergy([FromBody]Allergy allergy)
        {
            _service.PostAllergy(allergy);
            return Accepted();
        }

        // DELETE: api/Bolest/5
        [HttpDelete("{id}")]
        public ActionResult<Allergy> DeleteAllergy(int id)
        {
            _service.DeleteAllergy(id);
            return Accepted();
        }
    }
}
