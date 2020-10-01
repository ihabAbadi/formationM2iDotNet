using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        IHash _hash;

        public UserController(IHash hash)
        {
            _hash = hash;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Form(string route = null)
        {
            ViewBag.Route = route;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string route)
        {
            string compareHash = _hash.GetHash(SHA256.Create(), password);
            Euser user = DataContext.Instance.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == email && u.Password == compareHash);
            if(user != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.LastName+ " "+user.FirstName),
                    new Claim(ClaimTypes.Role, user.Role.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties option = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddDays(1)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), option);
                return Redirect(route);
            }
            else
            {
                ViewBag.Error = "Erreur de connexion";
                ViewBag.Route = route;
                return View("Form");
            }
        }
        [HttpPost]
        public IActionResult SignIn([FromForm]Euser user)
        {
            user.Role = DataContext.Instance.Roles.Find(2);
            user.Password = _hash.GetHash(SHA256.Create(),user.Password);
            DataContext.Instance.Users.Add(user);
            DataContext.Instance.SaveChanges();
            return RedirectToAction("Form");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Form");
        }

        public IActionResult Denied()
        {
            return View();
        }

        
    }
}
