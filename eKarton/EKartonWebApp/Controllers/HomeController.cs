using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EKartonWebApp.Models;
using EKartonWebApp.ViewModels;

namespace EKartonWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(HomeVM model)
        {
            Tip tip = model.Tip;
            if(tip == Tip.Lekar)
            {
                return View("LekarView");
            }
            else
            {
                return View("PacijentView");
            }
            return View();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
