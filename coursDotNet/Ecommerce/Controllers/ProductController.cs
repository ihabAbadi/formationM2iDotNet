using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _env;
        public ProductController(IWebHostEnvironment env)
        {
            _env = env;
        }
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

        public IActionResult FormProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm([FromForm] Product product, List<IFormFile> imagesProduct)
        {
            if(product.Add())
            {
                foreach(IFormFile i in imagesProduct)
                {
                    Image image = new Image()
                    {
                        ProductId = product.Id,
                        Url = Upload(i)
                    };
                    image.Add();
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Erreur d'ajout";
                return View("FormProduct");
            }
        }

        private string Upload(IFormFile image)
        {
            string uniqueString = Guid.NewGuid().ToString();
            string basePath = @"images/" + uniqueString + "-" + image.FileName;
            string path = Path.Combine(_env.WebRootPath, basePath);
            Stream s = System.IO.File.Create(path);
            image.CopyTo(s);
            s.Close();
            return basePath;
        }
    }
}
