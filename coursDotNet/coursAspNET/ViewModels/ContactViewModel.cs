using coursAspNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursAspNET.ViewModels
{
    public class ContactViewModel
    {
        public List<Contact> ListeContact { get; set; }

        public Contact Contact {get;set; }
    }
}
