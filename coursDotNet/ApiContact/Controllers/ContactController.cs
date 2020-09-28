using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiContact.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiContact.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DataContext.Instance.Contacts.Include(c => c.Emails).ToList());
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            return Ok(DataContext.Instance.Contacts.Include(c => c.Emails).FirstOrDefault( c => c.Id == id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            DataContext.Instance.Contacts.Add(contact);
            DataContext.Instance.SaveChanges();
            return Ok(new { message = "succeed", id=contact.Id});
        }

        [HttpPost("{id}/mail")]
        public IActionResult Post([FromBody] Email email,int id)
        {
            Contact c = DataContext.Instance.Contacts.Include(c => c.Emails).FirstOrDefault(c => c.Id == id);
            c.Emails.Add(email);
            DataContext.Instance.SaveChanges();
            return Ok(new { message = "succeed"});
        }



        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Contact contact, int id)
        {
            Contact c = DataContext.Instance.Contacts.Include(c => c.Emails).FirstOrDefault(c => c.Id == id);
            c.Nom = contact.Nom;
            c.Prenom = contact.Prenom;
            c.Emails.Clear();
            c.Emails = contact.Emails;
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

        [HttpDelete("{id}/email/{emailId}")]
        public IActionResult Delete(int id, int emailId)
        {
            //DataContext.Instance.Contacts.Include(c => c.Emails).FirstOrDefault(c => c.Id == id).Emails.Remove(DataContext.Instance.Contacts.Include(c => c.Emails).FirstOrDefault(c => c.Id == id).Emails.FirstOrDefault(e => e.Id == emailId));
            Contact c = DataContext.Instance.Contacts.Include(c => c.Emails).FirstOrDefault(c => c.Id == id);
            c.Emails.Remove(c.Emails.FirstOrDefault(e => e.Id == emailId));
            DataContext.Instance.SaveChanges();
            return Ok(new { message = "succeed" });
        }
    }
}
