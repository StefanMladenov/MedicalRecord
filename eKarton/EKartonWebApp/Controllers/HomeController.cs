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
            return View("~/Views/Logged/Index.cshtml");
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
    }
}
