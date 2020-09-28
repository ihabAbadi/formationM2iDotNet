using Ecommerce.Models;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        [Authorize(Policy = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }
        [Authorize(Policy = "customer")]
        [HttpGet]
        public IActionResult RecapOrder()
        {
            Cart cart;
            string cartString = HttpContext.Session.GetString("Cart");
            if (cartString != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartString);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
            return View(cart);
        }

        [Authorize(Policy = "customer")]
        [HttpGet]
        public IActionResult ConfirmOrder()
        {
            Cart cart;
            string cartString = HttpContext.Session.GetString("Cart");
            if (cartString != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartString);
                Order order = new Order();
                string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                order.User = DataContext.Instance.Users.FirstOrDefault(x => x.Email == email);
                foreach(ProductCart p in cart.Products)
                {
                    ProductOrder po = new ProductOrder()
                    {
                        Qty = p.Qty,
                        Product = DataContext.Instance.Products.Find(p.Product.Id)
                    };
                    order.Products.Add(po);
                }
                order.Total = cart.Total;
                DataContext.Instance.Add(order);
                DataContext.Instance.SaveChanges();
                return View(order);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
            
        }
    }
}
