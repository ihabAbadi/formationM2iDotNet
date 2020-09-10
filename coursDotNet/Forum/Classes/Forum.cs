using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Classes
{
    public class Forum : IForum
    {
        private int id;
        private string nom;
        private DateTime dateCreation;
        private List<Abonne> abonnes;
        private IModerateur moderateur;
        private List<Nouvelle> nouvelles;
        private static int index = 0;
        public int Id { get => id; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation;}
        public List<Abonne> Abonnes { get => abonnes; set => abonnes = value; }
        public IModerateur Moderateur { get => moderateur; set => moderateur = value; }
        public List<Nouvelle> Nouvelles { get => nouvelles; set => nouvelles = value; }
        
        public Forum()
        {
            id = ++index;
            dateCreation = DateTime.Now;
            Abonnes = new List<Abonne>();
            Nouvelles = new List<Nouvelle>();
        }
        public Forum(string nom, IModerateur moderateur) : this()
        {
            Nom = nom;
            Moderateur = moderateur;
        }

        public Abonne GetAbonneById(int id)
        {
            //Abonne abonne = null;
            //foreach(Abonne a in Abonnes)
            //{
            //    if(a.Id== id)
            //    {
            //        abonne = a;
            //        break;
            //    }
            //}
            //return abonne;
            //Abonne abonne = Abonnes.FirstOrDefault((a) =>  a.Id == id);
            return Abonnes.FirstOrDefault((a) => a.Id == id);
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
