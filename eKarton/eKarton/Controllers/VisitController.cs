using eKarton.Models;
using eKarton.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eKarton.Controllers
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

        [HttpGet]
        public ActionResult<List<Visit>> Get() =>
            _visitService.GetAll();

        [HttpGet("GetByGuid/{guid}")]
        public ActionResult<Visit> GetVisit(string guid)
        {
            var visit = _visitService.GetByGuid(guid);
            if (visit == null)
            {
                return NotFound();
            }
            return visit;
        }

        [HttpGet("GetByMRGuid/{guid}")]
        public ActionResult<List<Visit>> GetVisitByMedicalRecordGuid(string guid)
        {
            return _visitService.GetAllByRecordGuid(guid);
        }

        [HttpGet("GetByPatientUcin/{ucin}")]
        public ActionResult<List<Visit>> GetVisitByPatientUCIN(string ucin)
        {
            return _visitService.GetAllByPatientUCIN(ucin);
        }

        [HttpPost]
        public ActionResult<Visit> PostVisit([FromBody]Visit visit)
        {
            if (ModelState.IsValid)
            {
                var _visit = _visitService.GetByGuid(visit.Guid);
                if (_visit != null)
                {
                    return BadRequest();
                }
                _visitService.Create(visit);
                return Created("PostVisit", visit);
            }
            return BadRequest();
        }

        [HttpPut("{guid}")]
        public IActionResult PutVisit(string guid, [FromBody] Visit visitIn)
        {
            var visit = _visitService.GetByGuid(guid);
            if (visit == null)
            {
                _visitService.Create(visitIn);
                return Created("PutVisit", visitIn);
            }
            _visitService.Update(guid, visit, visitIn);
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
            return Accepted();
        }
    }
}