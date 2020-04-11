using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eMedicalRecord.Models.SQL;
using eMedicalRecord.Services;

namespace eMedicalRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnamnesisController : ControllerBase
    {
        private readonly IService<Anamnesis> _service;

        public AnamnesisController(MedicalRecordContext context)
        {
            _service = new AnamnesisService(context);
        }

        // GET: api/Anamnesis
        [HttpGet]
        public ActionResult<IEnumerable<Anamnesis>> GetAnamnesies()
        {
            return  _service.GetAll();
        }

        // GET: api/Anamnesis/guid
        [HttpGet("{guid}")]
        public ActionResult<Anamnesis> GetAnamnesis(string guid)
        {
            var anamnesis = _service.GetByGuid(guid);
            if (anamnesis == null)
            {
                return NotFound();
            }
            return anamnesis;
        }

        // PUT: api/Anamnesis/guid
        [HttpPut("{guid}")]
        public IActionResult PutAnamnesis(string guid, [FromBody] Anamnesis anamnesis)
        {
            if (ModelState.IsValid)
            {
                var anamn = _service.GetByGuid(guid);
                if (anamn != null)
                {
                    _service.Update(guid, anamnesis, anamn);
                    return Accepted();
                }
                else
                {
                    _service.Create(anamnesis);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Anamnesis
        [HttpPost]
        public ActionResult<Anamnesis> PostAnamnesis([FromBody]Anamnesis anamnesis)
        {
            if(_service.GetByGuid(anamnesis.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(anamnesis);
            return CreatedAtAction("PostAnamnesis", new { guid = anamnesis.Guid }, anamnesis);
        }

        // DELETE: api/Anamnesis/guid
        [HttpDelete("{guid}")]
        public ActionResult<Anamnesis> DeleteAnamnesis(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
