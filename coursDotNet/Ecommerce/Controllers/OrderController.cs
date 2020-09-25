using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Policy = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }
        [Authorize(Policy = "customer")]
        [HttpPost]
        public IActionResult ConfirmOrder()
        {
            return View();
        }
    }
}
