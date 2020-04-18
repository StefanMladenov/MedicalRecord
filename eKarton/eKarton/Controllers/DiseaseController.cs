using eKarton.Models.SQL;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseaseController : ControllerBase
    {
        private readonly IService<Disease> _service;

        public DiseaseController(IService<Disease> service)
        {
            _service = service;
        }

        // GET: api/Disease
        [HttpGet]
        public ActionResult<IEnumerable<Disease>> GetDiseases()
        {
            return _service.GetAll();
        }

        // GET: api/Disease/5
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

        // PUT: api/Disease/5
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

        // POST: api/Disease
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

        // DELETE: api/Disease/5
        [HttpDelete("{guid}")]
        public ActionResult<Disease> DeleteDisease(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
