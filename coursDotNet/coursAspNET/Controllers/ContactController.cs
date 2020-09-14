using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coursAspNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace coursAspNET.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            Contact c = new Contact() { Nom = "toto", Prenom = "tata" };
            ViewData["monContact"] = c;
            List<Contact> contacts = new List<Contact>()
            {
                new Contact() { Nom = "titi", Prenom = "minet"},
                new Contact() { Nom = "tt", Prenom = "ttt"},
            };
            ViewData["listeContacts"] = contacts;
            return View();
        }

        public IActionResult Accueil()
        {
            return View();
            //return new ContentResult() { Content = "<h1>Bonjour page contact</h1>" };
        }
    }
}
