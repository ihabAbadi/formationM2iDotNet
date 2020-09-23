using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Models
{
    public class Categorie
    {
        private int id;

        private string title;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }

        public List<AnnonceCategorie> Annonces { get; set; }
    }
}
