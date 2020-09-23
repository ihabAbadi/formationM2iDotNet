using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Models
{
    public class AnnonceCategorie
    {
        private int id;

        public int Id { get => id; set => id = value; }

        public Categorie Categorie { get; set; }

        public Annonce Annonce { get; set; }
    }
}
