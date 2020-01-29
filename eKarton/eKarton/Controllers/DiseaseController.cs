using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly DiseaseService _service;

        public DiseaseController(MedicalRecordContext context)
        {
            _service = new DiseaseService(context);
        }

        // GET: api/Bolest
        [HttpGet]
        public ActionResult<IEnumerable<Disease>> GetDiseases()
        {
            return _service.GetDiseases();
        }

        // GET: api/Bolest/5
        [HttpGet("{id}")]
        public ActionResult<Disease> GetDisease(int id)
        {
            var disease = _service.GetDisease(id);
            if (disease == null)
            {
                return NotFound();
            }

            return disease;
        }

        // PUT: api/Bolest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public ActionResult<Disease> PutDisease(int id, [FromBody] Disease disease)
        {
            if (id != disease.Id)
            {
                return BadRequest();
            }
            _service.PutDisease(id, disease);
            return NoContent();
        }

        // POST: api/Bolest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Disease> PostDisease([FromBody]Disease disease)
        {
            _service.PostDisease(disease);
            return Accepted();
        }

        // DELETE: api/Bolest/5
        [HttpDelete("{id}")]
        public ActionResult<Disease> DeleteDisease(int id)
        {
            _service.DeleteDisease(id);
            return Accepted();
        }
    }
}
