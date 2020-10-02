using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Authorize("customer")]
        [EnableCors("AcceptAll")]
        public IActionResult Post([FromBody]Order order)
        {
            string email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            order.User = DataContext.Instance.Users.FirstOrDefault((u) => u.Email == email);
            order.Products.ForEach(p =>
            {
                p.Product = Product.GetProductById(p.Product.Id);
            });
            DataContext.Instance.Orders.Add(order);
            DataContext.Instance.SaveChanges();
            return Ok(new { error = false, message = "order created", id = order.Id });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DataContext.Instance.Orders.Include(p => p.Products).ThenInclude(po => po.Product).ThenInclude(pp => pp.Images).ToList());
        }
    }
}
