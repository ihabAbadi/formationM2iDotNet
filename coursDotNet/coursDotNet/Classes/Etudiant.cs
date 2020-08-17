using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Etudiant : Personne
    {
        private int niveau;

        public int Niveau { get => niveau; set => niveau = value; }

        public Etudiant()
        {

        }
        public Etudiant(string n, string p) : base(n,p)
        {

        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Niveau : " + Niveau);
        }
        //public void AfficherInfo()
        //{
        //    Console.WriteLine(nom);
        //}

        public override string ToString()
        {
            return Nom + " "+ Prenom + " "+ Niveau;
        }
    } 
}
