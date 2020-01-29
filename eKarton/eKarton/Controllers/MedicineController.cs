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
        private readonly MedicineService _service;
        public MedicineController(MedicalRecordContext context)
        {
            _service = new MedicineService(context);
        }

        // GET: api/Medicine
        [HttpGet]
        public ActionResult<IEnumerable<Medicine>> GetMedicines()
        {
            return _service.GetMedicines();
        }

        // GET: api/Medicine/5
        [HttpGet("{id}")]
        public ActionResult<Medicine> GetMedicine(int id)
        {
            var medicine = _service.GetMedicine(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine;
        }

        // PUT: api/Medicine/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutMedicine(int id, [FromBody]Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return BadRequest();
            }
            _service.PutMedicine(id, medicine);
            return NoContent();
        }

        // POST: api/Medicine
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Medicine> PostMedicine([FromBody]Medicine medicine)
        {
            _service.PostMedicine(medicine);
            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }

        // DELETE: api/Medicine/5
        [HttpDelete("{id}")]
        public ActionResult<Medicine> DeleteMedicine(int id)
        {
            _service.DeleteMedicine(id);
            return Accepted();
        }
    }
}
