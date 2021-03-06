﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _env;
        private IUpload _service;
        private ITranslate _translator;
        private ILog _log;
        public ProductController(IWebHostEnvironment env, IUpload service, ITranslate translator, ILog log)
        {
            _env = env;
            _service = service;
            _translator = translator;
            _log = log;
        }
        //Liste des produits
        public IActionResult Index()
        {
            List<Product> products = Product.GetProducts();
            //products.ForEach(p => p.Images = Image.GetImagesByProduct(p.Id));
            return View(products);
        }
        //Detail du produit
        public IActionResult Detail(int id)
        {
            Product p = null;
            try
            {
                p = Product.GetProductById(id);
                //p.Images = Image.GetImagesByProduct(p.Id);
            }
            catch (Exception e)
            {
                _log.Logging(e.Message);
            }

            return View(p);
        }
        [Authorize(Policy = "admin")]
        public IActionResult FormProduct()
        {
            return View();
        }
        [Authorize(Policy = "admin")]
        [HttpPost]
        public IActionResult SubmitForm([FromForm] Product product, List<IFormFile> imagesProduct)
        {
            //if(product.Add())
            //{
            //    //UploadService _service = new UploadService(_env);
            //    foreach(IFormFile i in imagesProduct)
            //    {
            //        Image image = new Image()
            //        {
            //            ProductId = product.Id,
            //            Url = _service.Upload(i)
            //        };
            //        image.Add();
            //    }
            //    return RedirectToAction("Index");
            //}

            //UploadService _service = new UploadService(_env);
            foreach (IFormFile i in imagesProduct)
            {
                Image image = new Image()
                {
                    Url = _service.Upload(i)
                };
                product.Images.Add(image);


            }
            if (product.Add())
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Erreur d'ajout";
                return View("FormProduct");
            }
        }

        public IActionResult ChangeLanguage(string id)
        {
            _translator.ChangeLang(id);
            return RedirectToAction("Index");
        }
    }
}
