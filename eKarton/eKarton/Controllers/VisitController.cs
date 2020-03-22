using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eKarton.Services;
using eKarton.Models;

namespace eKarton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly VisitService _visitService;

        public VisitController(VisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet (Name="GetVisits")]
        public ActionResult<List<Visit>> Getttt() =>
            _visitService.Get();

        [HttpGet("{id:length(24)}", Name = "GetVisit")]
        public ActionResult<Visit> Get(string id)
        {
            var visit = _visitService.Get(id);

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

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Visit visitIn)
        {
            var visit = _visitService.Get(id);

            if (visit == null)
            {
                return NotFound();
            }

            _visitService.Update(id, visitIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteVisit(string id)
        {
            var visit = _visitService.Get(id);

            if (visit == null)
            { 
                return NotFound();
            }

            _visitService.Remove(visit.Guid);

            return NoContent();
        }
    }
}