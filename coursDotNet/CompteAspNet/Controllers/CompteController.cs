using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompteAspNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompteAspNet.Controllers
{
    public class CompteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Accueil");
        }

        public IActionResult Search(string numero)
        {
            return View("Accueil", Sauvegarde.Instance.ChercherComptes(numero).ToList());
        }

        [HttpGet]
        public IActionResult Detail(string numero)
        {
            Compte compte = Sauvegarde.Instance.ChercherCompte(numero);
            if(compte != null)
            {
                compte.Operations = Sauvegarde.Instance.getOperations(compte.Id);
            }
            return View("DetailCompte",compte);
        }

        [HttpGet]
        public IActionResult CreationCompte()
        {
            return View("FormCompte");
        }

        [HttpPost]
        public IActionResult SubmitCompte([FromForm]Compte compte)
        {
            return RedirectToAction("Detail", new { numero = compte.Numero }); 
        }

        [HttpGet]
        public IActionResult FormOperation(string numero, string type)
        {
            return View("FormOperation");
        }

        [HttpPost] 
        public IActionResult SubmitOperation([FromForm] Operation operation)
        {
            return RedirectToAction("Detail");
        }
    }
}
