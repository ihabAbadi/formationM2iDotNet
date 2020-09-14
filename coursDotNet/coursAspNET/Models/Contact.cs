using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursAspNET.Models
{
    public class Contact
    {
        private string nom;

        private string prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
