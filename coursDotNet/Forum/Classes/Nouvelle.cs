using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    class Nouvelle
    {
        private int id;
        private string sujet;
        private string contenu;
        private DateTime dateCreation;
        private string statut;
        private Abonne abonne;

        private static int index = 0;
        public int Id { get => id; }
        public string Sujet { get => sujet; set => sujet = value; }
        public string Contenu { get => contenu; set => contenu = value; }
        public DateTime DateCreation { get => dateCreation; }
        public string Statut { get => statut; set => statut = value; }
        internal Abonne Abonne { get => abonne; }

        public Nouvelle()
        {
            id = ++index;
            dateCreation = DateTime.Now;
        }

        public Nouvelle(string sujet, string contenu, Abonne abonne) : this()
        {
            Sujet = sujet;
            Contenu = contenu;
            Statut = "Non publiée";
            this.abonne = abonne;
        }

        public override string ToString()
        {
            return "Id Nouvelle : "+Id+" \n" +
                "Statut : " + Statut + " \n" +
                "Abonne : " + Abonne.ToString() +" \n" +
                "Sujet : "+ Sujet +"\n" +
                "Contenu : "+Contenu;
        }
    }
}
