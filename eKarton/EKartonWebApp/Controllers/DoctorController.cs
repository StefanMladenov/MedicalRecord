using System.Collections.Generic;
using EKartonWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EKartonWebApp.Controllers
{
    public class DoctorController : Controller
    {
        private List<DoctorDTO> _doctors;
        eKartonAPI _api = eKartonAPI.GetInstance();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostDoctor(DoctorVM vm)
        {
            if (ModelState.IsValid)
            {
                DoctorDTO doctor = new DoctorDTO();
                doctor.FirstName = vm.FirstName;
                doctor.LastName = vm.LastName;
                doctor.UniqueCitizensIdentityNumber = vm.UniqueCitizensIdentityNumber;
                doctor.DateOfBirth = vm.Date;
                _api.Create(doctor, Routes.APIBaseURI + Routes.PostDoctor);
                return View("Success");
            }
            else
            {
                return View("GetDoctors");
            }
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            _doctors = new List<DoctorDTO>(_api.GetAll<DoctorDTO>(Routes.GetDoctors));
            return View(_doctors);
        }

        //[HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            _api.Delete(id.ToString(), Routes.APIBaseURI + Routes.DeleteDoctor);
            return View("Success");
        }
    }
}
