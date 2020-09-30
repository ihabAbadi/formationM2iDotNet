using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IHash _hash;

        public UserController(IHash hash)
        {
            _hash = hash;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Euser user)
        {
            user.Password = _hash.GetHash(SHA256.Create(), user.Password);
            DataContext.Instance.Users.Add(user);

            DataContext.Instance.SaveChanges();
            return Ok(new { message = "user added", id = user.Id });
        }
    }
}
