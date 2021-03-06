﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContact.Models
{
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public List<Email> Emails { get; set; }

        public Contact()
        {
            Emails = new List<Email>();
        }
    }
}
