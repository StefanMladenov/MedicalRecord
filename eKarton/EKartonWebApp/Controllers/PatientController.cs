using System.Collections.Generic;
using EKartonWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKartonWebApp.Controllers
{
    public class PatientController : Controller
    {
        private List<PatientDTO> _patients;
        eKartonAPI _api = eKartonAPI.GetInstance();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostPatient(PatientVM vm)
        {
            if (ModelState.IsValid)
            {
                PatientDTO patient = new PatientDTO();
                patient.FirstName = vm.FirstName;
                patient.LastName = vm.LastName;
                patient.UniqueCitizensIdentityNumber = vm.UniqueCitizensIdentityNumber;
                patient.DateOfBirth = vm.Date;
                patient.MothersName = vm.MothersName;
                patient.FathersName = vm.FathersName;
                _api.Create(patient, Routes.APIBaseURI + Routes.PostPatient);
                return View("Success");
            }
            else
            {
                return View("GetDoctors");
            }
        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            _patients = new List<PatientDTO>(_api.GetAll<PatientDTO>(Routes.GetPatients));
            return View(_patients);
        }

        //[HttpDelete]
        public IActionResult DeletePatient(int id)
        {
            _api.Delete(id.ToString(), Routes.APIBaseURI + Routes.DeletePatient);
            return View("Success");
        }

        [HttpGet]
        public IActionResult GetPatient(int id)
        {
            PatientDTO patientDTO = _api.GetOne<PatientDTO>(id, Routes.GetPatient);
            PatientVM patient = new PatientVM();
            patient.FirstName = patientDTO.FirstName;
            patient.LastName = patientDTO.LastName;
            patient.UniqueCitizensIdentityNumber = patientDTO.UniqueCitizensIdentityNumber;
            patient.Date = patientDTO.DateOfBirth;
            patient.MothersName = patientDTO.MothersName;
            patient.FathersName = patientDTO.FathersName;
            return View("AddPatient", patient);
        }

        [HttpPost]
        public IActionResult PutPatient(int id, PatientVM vm)
        {
            return View();
        }
    }
}
