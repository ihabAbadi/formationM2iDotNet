using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnoncesAspNet.Models;
using AnnoncesAspNet.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AnnoncesAspNet.Controllers
{
    public class CategorieController : Controller
    {
        [HttpGet]
        public IActionResult FormCategorie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitCategorie([FromForm] Categorie categorie)
        {
            DataContext.Instance.Categories.Add(categorie);
            DataContext.Instance.SaveChanges();
            return RedirectToAction("Index", "Annonce");
        }
    }
}
