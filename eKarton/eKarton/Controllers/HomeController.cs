using Microsoft.AspNetCore.Mvc;

namespace eKarton.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("View");
        }
    }
}