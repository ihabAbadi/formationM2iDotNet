using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using coursAspNET.Models;
using coursAspNET.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coursAspNET.Controllers
{
    public class ContactController : Controller
    {
        private IWebHostEnvironment env;
        public ContactController(IWebHostEnvironment _env)
        {
            env = _env;
        }
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
            return View("Index", new { });
            //return View("~/Views/Contact/Accueil.cshtml");
            //return new ContentResult() { Content = "<h1>Bonjour page contact</h1>" };
        }

        public IActionResult FormContact()
        {
            return View();
        }

        //public IActionResult SubmitContact(string nom, string prenom, IFormFile image)
        //{
        //    Contact c = new Contact { Nom = nom, Prenom = prenom };
        //    string path = Path.Combine(env.WebRootPath, "upload", image.FileName);
        //    Stream s = System.IO.File.Create(path);
        //    image.CopyTo(s);
        //    s.Close();
        //    return View("FormContact", c);
        //}

        public IActionResult SubmitContact(string nom, string prenom, List<IFormFile> image)
        {
            Contact c = new Contact { Nom = nom, Prenom = prenom };
            foreach(IFormFile i in image)
            {
                string path = Path.Combine(env.WebRootPath, "upload", i.FileName);
                Stream s = System.IO.File.Create(path);
                i.CopyTo(s);
                s.Close();
            }
            
            return View("FormContact", c);
        }

        public IActionResult DetailContact(string id)
        {
            return new ContentResult { Content = "detail contact " + id };
        }
    }
}
