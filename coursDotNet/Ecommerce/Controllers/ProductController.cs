using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        //Liste des produits
        public IActionResult Index()
        {
            List<Product> products = Product.GetProducts();
            products.ForEach(p => p.Images = Image.GetImagesByProduct(p.Id));
            return View(products);
        }
        //Detail du produit
        public IActionResult Detail(int id)
        {
            Product p = Product.GetProductById(id);
            p.Images = Image.GetImagesByProduct(p.Id);
            return View(p);
        }
    }
}
