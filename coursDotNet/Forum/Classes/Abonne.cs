using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    public class Abonne
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string statut;
        private List<Nouvelle> nouvelles;
        private static int index = 0;
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public int Age { get => age; set => age = value; }
        public string Statut { get => statut; set => statut = value; }
        public List<Nouvelle> Nouvelles { get => nouvelles; }

        public Abonne()
        {
            id = ++index;
            nouvelles = new List<Nouvelle>();
            statut = "actif";
        }

        public Abonne(string n, string p, int a) : this()
        {
            Nom = n;
            Prenom = p;
            Age = a;
        }

        public Nouvelle CreerNouvelle(string sujet, string contenu)
        {
            Nouvelle nouvelle = new Nouvelle(sujet, contenu, this);
            Nouvelles.Add(nouvelle);
            return nouvelle;
        }
        public bool PublierNouvelle(Nouvelle nouvelle, Forum forum)
        {
            nouvelle.Statut = StatutNouvelle.Publie;
            forum.Nouvelles.Add(nouvelle);
            return true;
        }

        public Nouvelle RepondreNouvelle(Nouvelle nouvelle, string contenu)
        {
            return CreerNouvelle(nouvelle.Sujet, contenu);
        }

        public Nouvelle GetNouvelleById(int id)
        {
            Nouvelle nouvelle = null;
            foreach(Nouvelle n in Nouvelles)
            {
                if(n.Id == id)
                {
                    nouvelle = n;
                    break;
                }
            }
            return nouvelle;
        }
        public override string ToString()
        {
            return "Id : "+ Id +"" +
                " Nom : "+Nom +"" +
                " Prénom : "+Prenom +"" +
                " Age : "+Age +"" +
                " Statut : "+Statut;
        }
    }
}
