using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    sealed class Etudiant : Personne
    {
        private int niveau;

        private int age;

        public int Niveau { get => niveau; set => niveau = value; }
        public int Age { get => age; set {
                if (value >= 15 && value <= 25)
                    age = value;
                else
                    throw new AgeException();
            
            } 
        }

        public Etudiant()
        {

        }
        public Etudiant(string n, string p, int l) : base(n,p)
        {
            Niveau = l;
        }

        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Niveau : " + Niveau);
            Console.WriteLine("---Override with override---");
        }
        public new void AfficherWithNew()
        {
            base.AfficherWithNew();
            Console.WriteLine("Niveau : " + Niveau);
            Console.WriteLine("---Override with new---");
        }
        //public void AfficherInfo()
        //{
        //    Console.WriteLine(nom);
        //}

        public override string ToString()
        {
            return Nom + " "+ Prenom + " "+ Niveau;
        }

        public void SpecialEtudiant()
        {
            Console.WriteLine("Special etudiant");
        }
    } 
}
