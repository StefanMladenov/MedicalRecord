using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{guid}")]
        public IActionResult PutAnamnesis(string guid, [FromBody] Anamnesis anamnesis)
        {
            anamnesis.Guid = guid;
            if (_service.GetByGuid(guid) != null)
            {
                _service.Update(guid, anamnesis);
                return Accepted();
            }
            else
            {
                _service.Create(anamnesis);
                return Created("guid", guid);
            }
        }

        // POST: api/Anamnesis
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Anamnesis> PostAnamnesis([FromBody]Anamnesis anamnesis)
        {
            if(_service.GetByGuid(anamnesis.Guid) != null)
            {
                return BadRequest();
            }
            _service.Create(anamnesis);
            return CreatedAtAction("PostAnamnesis", new { guid = anamnesis.Guid }, anamnesis);
        }

        // DELETE: api/Anamnesis/5
        [HttpDelete("{id}")]
        public ActionResult<Anamnesis> DeleteAnamnesis(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
