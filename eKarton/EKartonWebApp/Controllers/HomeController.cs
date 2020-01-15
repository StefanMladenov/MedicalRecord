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
            return View();
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
        public /*async Task*/ IActionResult PutLekar(LekarVM vm)
        {
            //HttpClient cli = _api.InitializeClient();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/api/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            LekarDTO lekar = new LekarDTO();
            lekar.Ime = vm.Ime;
            lekar.Prezime = vm.Prezime;
            var myContent = JsonConvert.SerializeObject(lekar);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            var dd = client.PostAsync("Lekar/PostLekar", content);
            return View("Lekar"); 
        }

        [HttpGet]
        public IActionResult Lekar()
        {
            return View("Lekar");
        }

        [HttpGet]
        public IActionResult GetLekari()
        {
            List<LekarDTO> list = _api.GetAll<LekarDTO>("Lekar/GetLekari");
            //List<LekarDTO> list = _api.GetAll("/Lekar/GetLekari");
            return View(list);
        }
    }
}
