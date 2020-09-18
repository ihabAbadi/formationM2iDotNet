using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        //Afficher Panier
        public IActionResult Index()
        {
            Cart cart;
            string cartString = HttpContext.Session.GetString("Cart");
            if (cartString != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartString);
            }
            else
            {
                cart = new Cart();
            }
            return View(cart);
        }

        public IActionResult AddProductToCart(int id, int qty)
        {
            Cart cart;
            Product product = Product.GetProductById(id);
            product.Images = Image.GetImagesByProduct(product.Id);
            string cartString = HttpContext.Session.GetString("Cart");
            if (cartString != null)
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartString);
            }else
            {
                cart = new Cart();
            }
            cart.AddProduct(product, qty);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProductFromCart(int id)
        {
            return View();
        }
    }
}
