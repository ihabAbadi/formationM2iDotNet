using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFichier.Models
{
    class ExtensionFichier
    {
        private string nom;

        public string Nom { get => nom; set => nom = value; }

        public override string ToString()
        {
            return Nom;
        }
    }
}
