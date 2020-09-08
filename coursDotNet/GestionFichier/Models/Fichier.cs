using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFichier.Models
{
    class Fichier
    {
        private string nom;
        private string chemin;
        private ExtensionFichier extension;

        public string Nom { get => nom; set => nom = value; }
        public string Chemin { get => chemin; set => chemin = value; }
        public ExtensionFichier Extension { get => extension; set => extension = value; }

        public Fichier(string chemin)
        {
            Chemin = chemin;
            Nom = Path.GetFileNameWithoutExtension(chemin);
            Extension = new ExtensionFichier() { Nom = Path.GetExtension(chemin) };
        }
    }
}
