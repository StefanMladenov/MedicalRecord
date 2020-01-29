using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKartonWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EKartonWebApp.Controllers
{
    public class DoctorController : Controller
    {
        private List<DoctorDTO> _doctors;
        private static string _controllerName = "Doctor/";
        eKartonAPI _api = eKartonAPI.GetInstance();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public /*async Task*/ IActionResult PostDoctor(DoctorVM vm)
        {
            if (ModelState.IsValid)
            {
                DoctorDTO doctor = new DoctorDTO();
                doctor.FirstName = vm.FirstName;
                doctor.LastName = vm.LastName;
                doctor.UniqueCitizensIdentityNumber = vm.UniqueCitizensIdentityNumber;
                _api.Create(doctor, Routes.APIBaseURI + _controllerName + Routes.PostDoctor);
                //return Redirect(Routes.GetDoctors);
                return View("Deleted");
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
            _doctors = new List<DoctorDTO>(_api.GetAll<DoctorDTO>(_controllerName + Routes.GetDoctors));
            return View(_doctors);
        }

        //[HttpDelete]
        public IActionResult DeleteDoctorAsync(int id)
        {
            _api.Delete(id, Routes.APIBaseURI + _controllerName + Routes.DeleteDoctor);
            return View("Deleted");
        }
    }
}
