using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Interface;
using Ecommerce.Models;
using Ecommerce.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AcceptAll")]
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] Euser user)
        {
            Euser userFound = DataContext.Instance.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == _hash.GetHash(SHA256.Create(), user.Password));
            if(userFound != null)
            {
                string token = GenerateToken(userFound);
                return Ok(new { token, name = userFound.FirstName +" "+ userFound.LastName});
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpGet]
        //public IActionResult GetToken()
        //{
        //    return Ok(new { token = GenerateToken() });
        //}

        private string GenerateToken(Euser user)
        {
            SigningCredentials credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bonjour tout le monde")), SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " "+user.LastName),
            };
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer : "m2i",
                audience : "m2i",
                claims : claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:credentials);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;
        }

        [HttpGet("testToken")]
        [Authorize("customer")]
        public IActionResult TestToken()
        {
            return Ok();
        }
    }
}
