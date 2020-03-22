using System.Collections.Generic;
using System.Threading.Tasks;
using EKartonWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKartonWebApp.Controllers
{
    public class VisitController : Controller
    {
        private List<VisitDTO> _visits;
        eKartonAPI _api = eKartonAPI.GetInstance();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostVisit(VisitVM vm)
        {
            if (ModelState.IsValid)
            {
                VisitDTO visit = new VisitDTO();
                visit.FilePaths = vm.FilePaths;
                visit.DoctorUCIN = vm.DoctorUCIN;
                visit.PatientUCIN = vm.PatientUCIN;
                visit.Therapy = vm.Therapy;
                visit.HealthInsuranceNumber = vm.HealthInsuranceNumber;
                visit.CurrentFinding = vm.CurrentFinding;
                _api.Create(visit, Routes.APIBaseURI + Routes.PostVisit);
                return View("Success");
            }
            else
            {
                return View("GetVisits");
            }
        }

        [HttpGet]
        public IActionResult CreateVisit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetVisits()
        {
            _visits = new List<VisitDTO>(_api.GetAll<VisitDTO>(Routes.GetVisits));
            return View(_visits);
        }

        [HttpPost]
        public async Task<ActionResult> Create(VisitVM model)
        {
            var response = await _api.UploadFiles(model);
            if(response.IsSuccessStatusCode)
            {
                return View("Success");
            }
            return View("Unfortunately");
        }

        //[HttpDelete]
        public IActionResult DeleteVisitAsync(string Id)
        {
            _api.Delete(Id, Routes.APIBaseURI + Routes.DeleteVisit);
            return View("Success");
        }
    }
    
}