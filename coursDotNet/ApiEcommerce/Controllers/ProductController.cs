using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AcceptAll")]
    public class ProductController : ControllerBase
    {

        IUpload _upload;
        IDisplayer _displayer;
        public ProductController(IUpload upload, IDisplayer displayer)
        {
            _upload = upload;
            _displayer = displayer;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Product> liste = Product.GetProducts();
            liste.ForEach(p =>
            {
                p.Images.ForEach((i) =>
                {
                    i.Url = _displayer.ReWriteImageUrl(i.Url);
                });
            });
            return Ok(liste);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product p = Product.GetProductById(id);
            p.Images.ForEach(i =>
            {
                i.Url = _displayer.ReWriteImageUrl(i.Url);
            });
            return Ok(p);
        }

        [HttpGet("search/{search}")]
        public IActionResult Get(string search)
        {
            return Ok(DataContext.Instance.Products.Include(p=>p.Images).Where(p => p.Title.Contains(search) ||p.Description.Contains(search)).ToList());
        }


        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            DataContext.Instance.Products.Add(product);
            DataContext.Instance.SaveChanges();
            return Ok(new { error = false, message = "product added", productId = product.Id });
        }

        [HttpPut("{id}/image")]
        public IActionResult Put(IFormFile image, int id)
        {
            Product product = DataContext.Instance.Products.Find(id);
            if(product != null)
            {
                Image img = new Image()
                {
                    Url = _upload.Upload(image)
                };
                product.Images.Add(img);
                DataContext.Instance.SaveChanges();
                return Ok(new { error = false, message = "image added"});
            }
            return Ok(new { error = true, message = "error adding image" });
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product product, int id)
        {
            Product p = Product.GetProductById(id);
            p.Images.Clear();
            if(p != null)
            {
                p.Title = product.Title;
                p.Description= product.Description;
                p.Price= product.Price;
                DataContext.Instance.SaveChanges();
                return Ok(new { error = false, message = "product updated" });
            }
            return Ok(new { error = true, message = "error updating product" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product p = Product.GetProductById(id);
            if(p != null)
            {
                DataContext.Instance.Products.Remove(p);
                DataContext.Instance.SaveChanges();
                return Ok(new { error = false, message = "product deleted" });
            }
            return Ok(new { error = true, message = "Error product delete"});
        }
    }
}
