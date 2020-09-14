using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EcoreAspNET.Controllers
{
    public class EcoleController : Controller
    {
        public IActionResult Listes()
        {
            return View();
        }

        public IActionResult EtudiantForm()
        {
            return View();
        }

        public IActionResult ProfForm()
        {
            return View();
        }
    }
}
