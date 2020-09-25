using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AnnoncesAspNet.Interface;
using AnnoncesAspNet.Models;
using AnnoncesAspNet.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<IActionResult> SubmitLogin(string email, string password)
        {
            string compareHash = _hash.GetHash(SHA256.Create(), password);
            Utilisateur utilisateur = DataContext.Instance.Utilisateurs.FirstOrDefault(u => u.Email == email && u.Password == compareHash);
            if(utilisateur != null)
            {
                //Garder la connexion dans les sessions, ainsi que les informations des utilisateurs
                //_login.SaveUser(utilisateur);
                //Utilisation du login avec AuthenticationCookie
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, utilisateur.Email),
                    new Claim("nomComplet", utilisateur.Nom + " "+utilisateur.Prenom),
                    new Claim(ClaimTypes.Role, "visiteur")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties option = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), option);
                return RedirectToAction("Index", "Annonce");
            }
            return View("FormLogin");
        }

        public async Task<IActionResult> LogOut()
        {
            //HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Annonce");
        }
    }
}
