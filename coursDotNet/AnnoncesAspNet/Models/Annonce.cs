using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Models
{
    public class Annonce
    {
        private int id;
        private string title;
        private string description;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

        public List<AnnonceCategorie> Categories { get; set; }

        public List<Image> Images { get; set; }

        public Annonce()
        {
            Categories = new List<AnnonceCategorie>();
            Images = new List<Image>();
        }
    }
}
