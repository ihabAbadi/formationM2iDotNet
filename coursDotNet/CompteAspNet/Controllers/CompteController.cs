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
            if (compte != null)
            {
                compte.Operations = Sauvegarde.Instance.getOperations(compte.Id);
            }
            return View("DetailCompte", compte);
        }

        [HttpGet]
        public IActionResult CreationCompte()
        {
            return View("FormCompte");
        }

        [HttpPost]
        public IActionResult SubmitCompte([FromForm] Compte compte)
        {
            if(Sauvegarde.Instance.CreationCompte(compte))
            {
                return RedirectToAction("Detail", new { numero = compte.Numero });
            }
            else
            {
                ViewBag.Message = "Erreur création compte";
                return View("FormCompte");
            }
        }

        [HttpGet]
        public IActionResult FormOperation(string numero, string type)
        {
            Compte compte = Sauvegarde.Instance.ChercherCompte(numero);
            if (compte == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Numero = numero;
            ViewBag.Type = type;
            return View("FormOperation");
        }

        [HttpPost]
        public IActionResult SubmitOperation([FromForm] string numero, [FromForm] string type, [FromForm] decimal montant)
        {
            Compte compte = Sauvegarde.Instance.ChercherCompte(numero);
            bool error = false;
            if (compte == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (type == "retrait")
                {
                    Operation o = new Operation(montant*-1, compte.Id);
                    error = !compte.Retrait(o);
                }
                else if(type =="depot")
                {
                    Operation o = new Operation(montant, compte.Id);
                    error = !compte.Depot(o);
                }
            }
            if(!error)
            {
                return RedirectToAction("Detail", new { numero = compte.Numero});
            }
            else
            {
                ViewBag.Numero = numero;
                ViewBag.Type = type;
                ViewBag.Message = "Error opération";
                return View("FormOperation");
            }
        }
    }
}
