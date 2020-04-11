using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eMedicalRecord.Services;
using eMedicalRecord.Models;
using eMedicalRecord.Models.SQL;

namespace eMedicalRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly VisitService _visitService;

        public VisitController(VisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet (Name="GetVisits")]
        public ActionResult<List<Visit>> Get() =>
            _visitService.GetAll();

        [HttpGet("{guid}")]
        public ActionResult<Visit> GetVisit(string guid)
        {
            var visit = _visitService.GetByGuid(guid);

            if (visit == null)
            {
                return NotFound();
            }

            return visit;
        }

        [HttpPost]
        public ActionResult<Visit> PostVisit(Visit visit)
        {
            Visit visit1 = new Visit();
            visit1.PatientUCIN = visit.PatientUCIN;
            visit1.DoctorUCIN = visit.DoctorUCIN;
            visit1.Therapy = visit.Therapy;
            visit1.WorkingDiagnosis = visit.WorkingDiagnosis;
            string[] lista = {"aaaaaa", "bbbbbbb" };
            
            visit1.FilePaths = lista;
            visit1.CurrentFinding = visit.CurrentFinding;
            visit1.UpdatedOn = visit.UpdatedOn;


            _visitService.Create(visit1);

            return CreatedAtRoute("GetVisit", new { id = visit1.Guid.ToString() }, visit1);
        }

        [HttpPut("{guid}")]
        public IActionResult Update(string guid, Visit visitIn)
        {
            var visit = _visitService.GetByGuid(guid);

            if (visit == null)
            {
                _visitService.Create(visitIn);
                return Accepted();
            }

            _visitService.Update(guid, visitIn);

            return Accepted();
        }

        [HttpDelete("{guid}")]
        public IActionResult DeleteVisit(string guid)
        {
            var visit = _visitService.GetByGuid(guid);

            if (visit == null)
            { 
                return NotFound();
            }

            _visitService.Remove(visit);

            return NoContent();
        }
    }
}