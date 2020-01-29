using Microsoft.AspNetCore.Mvc;

namespace EKartonWebApp.Controllers
{
    public class LoggedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Doctor()
        {
            return View();
        }
    }
}