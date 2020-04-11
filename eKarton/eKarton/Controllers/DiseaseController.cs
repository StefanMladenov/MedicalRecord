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
        private readonly IService<Disease> _service;

        public DiseaseController(MedicalRecordContext context)
        {
            _service = new DiseaseService(context);
        }

        // GET: api/Bolest
        [HttpGet]
        public ActionResult<IEnumerable<Disease>> GetDiseases()
        {
            return _service.GetAll();
        }

        // GET: api/Bolest/5
        [HttpGet("{guid}")]
        public ActionResult<Disease> GetDisease(string guid)
        {
            var disease = _service.GetByGuid(guid);
            if (disease == null)
            {
                return NotFound();
            }

            return disease;
        }

        // PUT: api/Bolest/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public ActionResult<Disease> PutDisease(string guid, [FromBody] Disease disease)
        {
            if (ModelState.IsValid)
            {
                var dis = _service.GetByGuid(guid);
                if (dis != null)
                {
                    _service.Update(guid, disease, dis);
                    return Accepted();
                }
                else
                {
                    disease.Guid = guid;
                    _service.Create(disease);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Bolest
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Disease> PostDisease([FromBody]Disease disease)
        {
            if (_service.GetByGuid(disease.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(disease);
            return CreatedAtAction("PostDisease", new { guid = disease.Guid }, disease);
        }

        // DELETE: api/Bolest/5
        [HttpDelete("{guid}")]
        public ActionResult<Disease> DeleteDisease(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
