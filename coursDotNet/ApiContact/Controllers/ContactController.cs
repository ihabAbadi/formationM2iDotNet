using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiContact.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Contact> liste = new List<Contact>();
            liste.Add(new Contact()
            {
                Nom = "toto",
                Prenom = "tata"
            });
            liste.Add(new Contact()
            {
                Nom = "abadi",
                Prenom = "ihab"
            });

            return Ok(liste);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Contact contact = new Contact()
            {
                Nom = "toto",
                Prenom = "tata"
            };
            return Ok(contact);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Contact contact, int id)
        {
            contact.Id = id;
            return Ok(contact);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
