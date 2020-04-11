using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Models.SQL;
using eKarton.Services;

namespace eKarton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IService<Medicine> _service;
        public MedicineController(MedicalRecordContext context)
        {
            _service = new MedicineService(context);
        }

        // GET: api/Medicine
        [HttpGet]
        public ActionResult<IEnumerable<Medicine>> GetMedicines()
        {
            return _service.GetAll();
        }

        // GET: api/Medicine/guid
        [HttpGet("{guid}")]
        public ActionResult<Medicine> GetMedicine(string guid)
        {
            var medicine = _service.GetByGuid(guid);
            if (medicine == null)
            {
                return NotFound();
            }
            return medicine;
        }

        // PUT: api/Medicine/guid
        [HttpPut("{guid}")]
        public IActionResult PutMedicine(string guid, [FromBody]Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                var med = _service.GetByGuid(guid);
                if (med != null)
                {
                    _service.Update(guid, medicine, med);
                    return Accepted();
                }
                else
                {
                    medicine.Guid = guid;
                    _service.Create(medicine);
                    return Created("guid", guid);
                }
            }
            return BadRequest();
        }

        // POST: api/Medicine
        [HttpPost]
        public ActionResult<Medicine> PostMedicine([FromBody]Medicine medicine)
        {
            if(_service.GetByGuid(medicine.Guid) != null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _service.Create(medicine);
            return CreatedAtAction("PostMedicine", new { guid = medicine.Guid }, medicine);
        }

        // DELETE: api/Medicine/guid
        [HttpDelete("{guid}")]
        public ActionResult<Medicine> DeleteMedicine(string guid)
        {
            _service.Delete(guid);
            return Accepted();
        }
    }
}
