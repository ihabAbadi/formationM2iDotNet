using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursAspNET.Models;
using coursAspNET.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace coursAspNET.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ContactViewModel vm = new ContactViewModel();
            Contact c = new Contact() { Nom = "toto", Prenom = "tata" };
            //ViewData["monContact"] = c;
            //ViewBag.monContact = c;
            vm.Contact = c;
            List<Contact> contacts = new List<Contact>()
            {
                new Contact() { Nom = "titi", Prenom = "minet"},
                new Contact() { Nom = "tt", Prenom = "ttt"},
            };
            vm.ListeContact = contacts;
            //ViewData["listeContacts"] = contacts;
            //ViewBag.listeContacts = contacts;
            return View(vm);
        }

        public IActionResult Accueil()
        {
            return View();
            //return new ContentResult() { Content = "<h1>Bonjour page contact</h1>" };
        }
    }
}
