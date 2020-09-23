using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnoncesAspNet.Models;
using AnnoncesAspNet.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AnnoncesAspNet.Controllers
{
    public class AnnonceController : Controller
    {
        public IActionResult Index()
        {
            DataContext data = new DataContext();
            Categorie c = new Categorie()
            {
                Title = "Voiture",
            };
            data.Categories.Add(c);
            Annonce a = new Annonce()
            {
                Title = "v1",
                Description = "description 1"
            };
            AnnonceCategorie categorie = new AnnonceCategorie()
            {
                Annonce = a,
                Categorie = c
            };
            a.Categories.Add(categorie);
            data.Annonces.Add(a);
            data.SaveChanges();
            return new JsonResult(new { ok = "Ok"});
        }
    }
}
