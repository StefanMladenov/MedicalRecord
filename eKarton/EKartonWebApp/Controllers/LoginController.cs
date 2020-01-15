using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EKartonWebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        eKartonAPI eKartonAPI = eKartonAPI.GetInstance();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View("Register");
        }
    }
}