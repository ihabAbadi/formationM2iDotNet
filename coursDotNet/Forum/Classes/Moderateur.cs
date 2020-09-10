using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    public class Moderateur : Abonne, IModerateur
    {
        public Moderateur() : base()
        {

        }

        public Moderateur(string n, string p, int a) : base(n, p, a)
        {

        }

        public Abonne AjouterAbonne(IForum forum, string nom, string prenom, int age)
        {
            Abonne abonne = new Abonne(nom, prenom, age);
            forum.Abonnes.Add(abonne);
            return abonne;
        }

        public bool SupprimerNouvelle(IForum forum, Nouvelle nouvelle)
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
