using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coursAspNET.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Accueil()
        {
            return View();
            //return new ContentResult() { Content = "<h1>Bonjour page contact</h1>" };
        }
    }
}
