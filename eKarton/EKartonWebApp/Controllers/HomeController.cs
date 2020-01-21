using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EKartonWebApp.Models;
using EKartonWebApp.ViewModels;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using System;

namespace EKartonWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        eKartonAPI _api = eKartonAPI.GetInstance();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(HomeVM model)
        {
            return View();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel LoginVM)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel rv)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public /*async Task*/ IActionResult PostDoctor(DoctorVM vm)
        {
            ////HttpClient cli = _api.InitializeClient();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:5001/api/");
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DoctorDTO doctor = new DoctorDTO();
            doctor.FirstName = vm.FirstName;
            doctor.LastName = vm.LastName;
            //var myContent = JsonConvert.SerializeObject(doctor);
            //var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            //var dd = client.PostAsync("https://localhost:5001/api/" + Routes.PostDoctor, content);
            _api.Create(doctor, Routes.PostDoctor);
            return View("Login");
            //return View("Doctor"); 
        }

        [HttpGet]
        public IActionResult Doctor()
        {
            return View("Doctor");
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            List<DoctorDTO> list = _api.GetAll<DoctorDTO>(Routes.GetDoctors);
            return View(list);
        }

        //[HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            _api.Delete(id,Routes.DeleteDoctor);
            return View();
        }
    }
}
