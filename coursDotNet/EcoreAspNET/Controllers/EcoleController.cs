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

        [HttpPost]
        public IActionResult SubmitEtudiant([FromForm]Etudiant e, int classe)
        {
            Etudiant etudiant = Etudiant.GetEtudiantById(e.Id);
            bool error = false;
            if(etudiant == null)
            {
                //Création Etudiant 
                error = !e.Save();
            }
            else
            {
                e.Classe = new Classe { Id = classe };
                e.PersonneId = etudiant.PersonneId;
                error = !e.Update();
            }
            if(error)
            {
                List<Classe> l = Classe.GetClasses();
                string message = "Erreur";
                string classCss = "danger";
                ViewBag.Message = message;
                ViewBag.ClassCss = classCss;
                return View("EtudiantForm", l);
            }
            else
            {
                return RedirectToAction("Listes");
            }
        }

        public IActionResult ProfForm()
        {
            return View(Matiere.getMatieres());
        }
        //public IActionResult SubmitProf(string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, int matiere, int? id)
        public IActionResult SubmitProf(Prof e,int Matiere)
        {
            Prof prof = Prof.GetProfById(e.Id);
            bool error = false;
            if(prof == null)
            {
                e.Matiere = new Matiere { Id = Matiere };
                error = !e.Save();
            }
            else
            {
                e.Matiere = new Matiere { Id = Matiere };
                e.PersonneId = prof.PersonneId;
                error = !e.Update();
            }
            if(error)
            {
                ViewBag.Message = "Erreur";
                ViewBag.ClassCss = "danger";
                return View("ProfForm", Ecole.Models.Matiere.getMatieres());
            }
            else
            {
                return RedirectToAction("Listes");
            }
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

        public IActionResult Edit(int id, string type)
        {
            if(type == "Ecole.Models.Etudiant")
            {
                Etudiant etudiant = Etudiant.GetEtudiantById(id);
                ViewBag.Etudiant = etudiant;
                return View("EtudiantForm", Classe.GetClasses());
            }
            else if(type == "Ecole.Models.Prof")
            {
                Prof prof = Prof.GetProfById(id);
                ViewBag.Prof = prof;
                return View("ProfForm", Matiere.getMatieres());
            }
            return RedirectToAction("Listes");
        }
    }
}
