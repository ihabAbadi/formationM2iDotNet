using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoreAspNET.Controllers
{
    public class EcoleController : Controller
    {
        public IActionResult Listes()
        {
            ViewBag.Etudiants = Etudiant.GetEtudiants();
            ViewData["Profs"] = Prof.GetProfs();
            return View();
        }

        public IActionResult EtudiantForm()
        {
            List<Classe> l = Classe.GetClasses();
            return View(l);
        }

        public IActionResult SubmitEtudiant(string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, int classe)
        {
            List<Classe> l = Classe.GetClasses();
            string message = null;
            string classCss= null;
            Etudiant e = new Etudiant
            {
                Nom = nom,
                Prenom = prenom,
                Telephone = telephone,
                Email = email,
                Adresse = adresse,
                Ville = ville,
                CodePostal = codePostal,
                Classe = new Classe { Id = classe }
            };
            if(e.Save())
            {
                message = "Etudiant ajouté";
                classCss = "success";
            }
            else
            {
                message = "Erreur d'ajout d'étudiant";
                classCss = "danger";
            }
            ViewBag.Message = message;
            ViewBag.ClassCss = classCss;
            return View("EtudiantForm",l);
        }

        public IActionResult ProfForm()
        {
            return View();
        }
    }
}
