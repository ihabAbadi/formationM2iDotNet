﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    class Forum
    {
        private int id;
        private string nom;
        private DateTime dateCreation;
        private List<Abonne> abonnes;
        private Moderateur moderateur;
        private List<Nouvelle> nouvelles;
        private static int index = 0;
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation;}
        public List<Abonne> Abonnes { get => abonnes; set => abonnes = value; }
        public Moderateur Moderateur { get => moderateur; set => moderateur = value; }
        public List<Nouvelle> Nouvelles { get => nouvelles; set => nouvelles = value; }
        
        public Forum()
        {
            id = ++index;
            dateCreation = DateTime.Now;
            Abonnes = new List<Abonne>();
            Nouvelles = new List<Nouvelle>();
        }
        public Forum(string nom, Moderateur moderateur)
        {
            Nom = nom;
            Moderateur = moderateur;
        }

        public Abonne GetAbonneById(int id)
        {
            Abonne abonne = null;
            foreach(Abonne a in Abonnes)
            {
                if(a.Id== id)
                {
                    abonne = a;
                    break;
                }
            }
            return abonne;
        }

        public Nouvelle GetNouvelleById(int id)
        {
            Nouvelle nouvelle = null;
            foreach (Nouvelle n in Nouvelles)
            {
                if (n.Id == id)
                {
                    nouvelle = n;
                    break;
                }
            }
            return nouvelle;
        }

    }
}
