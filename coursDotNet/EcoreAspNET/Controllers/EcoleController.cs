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
                return RedirectToAction("Listes");
            }
            else
            {
                message = "Erreur d'ajout d'étudiant";
                classCss = "danger";
                ViewBag.Message = message;
                ViewBag.ClassCss = classCss;
                return View("EtudiantForm",l);
            }  
        }

        public IActionResult SubmitProf(string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, int matiere)
        {
            
            string message = null;
            string classCss = null;
            Prof e = new Prof
            {
                Nom = nom,
                Prenom = prenom,
                Telephone = telephone,
                Email = email,
                Adresse = adresse,
                Ville = ville,
                CodePostal = codePostal,
                Matiere = new Matiere { Id = matiere}
            };
            if (e.Save())
            {
                message = "prof ajouté";
                classCss = "success";
                return RedirectToAction("Listes");
            }
            else
            {
                message = "Erreur d'ajout de prof";
                classCss = "danger";
                ViewBag.Message = message;
                ViewBag.ClassCss = classCss;
                return View("ProfForm", Matiere.getMatieres());
            }
        }

        public IActionResult ProfForm()
        {
            return View(Matiere.getMatieres());
        }

        public IActionResult DetailEtudiant(int id)
        {
            Etudiant etudiant = Etudiant.GetEtudiantById(id);
            if(etudiant != null)
            {
                return View("Detail",etudiant);
            }
            else
            {
                return RedirectToAction("Listes");
            }
        }

        public IActionResult DetailProf(int id)
        {
            Prof prof = Prof.GetProfById(id);
            if (prof != null)
            {
                return View("Detail",prof);
            }
            else
            {
                return RedirectToAction("Listes");
            }
        }
    }
}
