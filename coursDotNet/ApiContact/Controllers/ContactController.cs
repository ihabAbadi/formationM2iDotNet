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
            return Ok(DataContext.Instance.Contacts.ToList());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            return Ok(DataContext.Instance.Contacts.Find(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            DataContext.Instance.Contacts.Add(contact);
            DataContext.Instance.SaveChanges();
            return Ok(new { message = "succeed", id=contact.Id});
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Contact contact, int id)
        {
            Contact c = DataContext.Instance.Contacts.Find(id);
            c.Nom = contact.Nom;
            c.Prenom = contact.Prenom;
            DataContext.Instance.SaveChanges();
            return Ok(new { message = "succeed", id = c.Id });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contact c = DataContext.Instance.Contacts.Find(id);
            DataContext.Instance.Contacts.Remove(c);
            DataContext.Instance.SaveChanges();
            return Ok(new { message = "succeed", id = c.Id });
        }
    }
}
