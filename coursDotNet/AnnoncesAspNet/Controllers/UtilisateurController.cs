using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AnnoncesAspNet.Interface;
using AnnoncesAspNet.Models;
using AnnoncesAspNet.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AnnoncesAspNet.Controllers
{
    public class UtilisateurController : Controller
    {
        IHash _hash;
        ILogin _login;

        public UtilisateurController(IHash hash, ILogin login)
        {
            _login = login;
            _hash = hash;
        }
        public IActionResult SignInForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitSignIn([FromForm] Utilisateur utilisateur)
        {
            utilisateur.Password = _hash.GetHash(SHA256.Create(), utilisateur.Password);
            DataContext.Instance.Utilisateurs.Add(utilisateur);
            DataContext.Instance.SaveChanges();
            return RedirectToAction("FormLogin");
        }

        public IActionResult FormLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitLogin(string email, string password)
        {
            string compareHash = _hash.GetHash(SHA256.Create(), password);
            Utilisateur utilisateur = DataContext.Instance.Utilisateurs.FirstOrDefault(u => u.Email == email && u.Password == compareHash);
            if(utilisateur != null)
            {
                //Garder la connexion dans les sessions, ainsi que les informations des utilisateurs
                _login.SaveUser(utilisateur);
                return RedirectToAction("Index", "Annonce");
            }
            return View("FormLogin");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Annonce");
        }
    }
}
