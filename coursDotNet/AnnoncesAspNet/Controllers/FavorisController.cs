using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnoncesAspNet.Interface;
using AnnoncesAspNet.Models;
using AnnoncesAspNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AnnoncesAspNet.Controllers
{
    public class FavorisController : Controller
    {
        IFavoris _favoris;
        public FavorisController(IFavoris favoris)
        {
            _favoris = favoris;
        }

        public IActionResult Index()
        {
            AnnoncesViewModel vm = new AnnoncesViewModel();
            vm.Annonces = new List<Annonce>();
            _favoris.getFavoris().ForEach(id =>
            {
                vm.Annonces.Add(Annonce.GetAnnonce(id));
            });
            return View("~/Views/Annonces/Index.cshtml", vm);
        }
        public IActionResult AddToFavoris(int id)
        {
            Annonce annonce = Annonce.GetAnnonce(id);
            if(annonce != null)
            {
                _favoris.AddToFavoris(annonce.Id);
                return RedirectToAction("Detail", "Annonce", new { id = annonce.Id });
            }
            return RedirectToAction("Index", "Annonce");
        }

        public IActionResult RemoveFromFavoris(int id)
        {
            Annonce annonce = Annonce.GetAnnonce(id);
            if (annonce != null)
            {
                _favoris.RemoveFromFavoris(annonce.Id);
                return RedirectToAction("Detail", "Annonce", new { id = annonce.Id });
            }
            return RedirectToAction("Index", "Annonce");
        }
    }
}
