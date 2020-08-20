using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    class Moderateur : Abonne
    {
        public Moderateur() : base()
        {

        }

        public Moderateur(string n, string p, int a) : base(n, p, a)
        {

        }

        public bool AjouterAbonne(Forum forum, string nom, string prenom, int age)
        {
            Abonne abonne = new Abonne(nom, prenom, age);
            forum.Abonnes.Add(abonne);
            return true;
        }

        public bool SupprimerNouvelle(Forum forum, Nouvelle nouvelle)
        {
            forum.Nouvelles.Remove(nouvelle);
            return true;
        }

        public bool BannirAbonne(Abonne abonne)
        {
            abonne.Statut = "banni";
            return true;
        }

    }
}
