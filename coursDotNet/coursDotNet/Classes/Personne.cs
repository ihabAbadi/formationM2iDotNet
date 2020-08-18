using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    abstract class Personne
    {
        protected string nom;
        protected string prenom;

        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public Personne()
        {

        }
        public Personne(string n, string p)
        {
            Nom = n;
            Prenom = p;
        }

        public virtual void Afficher()
        {
            Console.WriteLine("Le nom est " + Nom + ", et le prénom : " + Prenom);
        }

        public virtual void AfficherWithNew()
        {
            Console.WriteLine("Le nom est " + Nom + ", et le prénom : " + Prenom);
        }
    }
}
