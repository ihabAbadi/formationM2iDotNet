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

        public IActionResult SubmitEtudiant(string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, int classe, int? id)
        {
            Etudiant etudiant = id != null ? Etudiant.GetEtudiantById((int)id) : null;
            bool error = false;
            if(etudiant == null)
            {
                //Création Etudiant 
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
                error = !e.Save();
            }
            else
            {
                etudiant.Nom = nom;
                etudiant.Prenom= prenom;
                etudiant.Telephone= telephone;
                etudiant.Adresse= adresse;
                etudiant.CodePostal= codePostal;
                etudiant.Ville= ville;
                etudiant.Email= email;
                etudiant.Classe = new Classe { Id = classe };
                error = !etudiant.Update();
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
        public IActionResult SubmitProf(string nom, string prenom, string email, string telephone, string adresse, string codePostal, string ville, int matiere, int? id)
        {
            Prof prof = id != null ? Prof.GetProfById((int)id) : null;
            bool error = false;
            if(prof == null)
            {
                Prof e = new Prof
                {
                    Nom = nom,
                    Prenom = prenom,
                    Telephone = telephone,
                    Email = email,
                    Adresse = adresse,
                    Ville = ville,
                    CodePostal = codePostal,
                    Matiere = new Matiere { Id = matiere }
                };
                error = !e.Save();
            }
            else
            {
                prof.Nom = nom;
                prof.Prenom = prenom;
                prof.Telephone = telephone;
                prof.Adresse = adresse;
                prof.CodePostal = codePostal;
                prof.Ville = ville;
                prof.Email = email;
                prof.Matiere = new Matiere { Id = matiere };
                error = !prof.Update();
            }
            if(error)
            {
                ViewBag.Message = "Erreur";
                ViewBag.ClassCss = "danger";
                return View("ProfForm", Matiere.getMatieres());
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
