using Microsoft.AspNetCore.Mvc;
using EKartonWebApp.ViewModels;
namespace EKartonWebApp.Controllers
{

    [Route("[controller]/[action]")]
    public class MedicalRecordController : Controller
    {
        private eKartonAPI _api = eKartonAPI.GetInstance();
        public IActionResult MedicalRecordMenu()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult MedicalRecordCreate(MedicalRecordCreateVM vm)
        {
            string path = "PatientController/PatientExists";
            var result = _api.Exists(vm.PatientUCIN, path);
            return View(result);
        }

        [HttpPost]
        public IActionResult MedicalRecordMainMenu(string email)
        {
            return View();
        }

    }
}