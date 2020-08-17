using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Album
    {
        private string nom;
        private string auteur;
        private Titre[] titres;
        private int index;

        public string Nom { get => nom; set => nom = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        
        public int NombreTitre { 
            get
            {
                return titres.Length;
            } 
        }
        public Album(int nombreTitre, string nom, string auteur)
        {
            titres = new Titre[nombreTitre];
            Nom = nom;
            Auteur = auteur;
            index = 0;
        }

        public void AjouterTitre(Titre titre)
        {
            if(index < titres.Length)
            {
                titres[index] = titre;
                index++;
            }
        }

        public string ListesTitres()
        {
            string retour = "";
            foreach(Titre t in titres)
            {
                retour += "Nom Titre : " + t.Nom + " Durée du titre : " + t.Duree;
            }
            return retour;
        }

        public Titre GetTitre(int index)
        {
            return titres[index];
        }

        
    }
}
