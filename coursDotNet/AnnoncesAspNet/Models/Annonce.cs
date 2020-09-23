using AnnoncesAspNet.Tools;
using Microsoft.EntityFrameworkCore;
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

        public static Annonce GetAnnonce(int id)
        {
            return DataContext.Instance.Annonces.Include(a => a.Images).Include(a => a.Categories).ThenInclude(c => c.Categorie).FirstOrDefault(a => a.Id == id);
        }

        public static List<Annonce> GetAnnonces(string chaine)
        {
            return DataContext.Instance.Annonces.Include(a => a.Images).Include(a => a.Categories).ThenInclude(c => c.Categorie).Where((a) => a.Title.Contains(chaine) ||a.Description.Contains(chaine)).ToList();
        }

        public static List<Annonce> GetAnnoncesByCategorie(int id)
        {
            //---------------------------------------------AnnoncesCategories-----------Annonce---------------------Images---------Categorie par id---------------Annonces categories---Selectionne Annonce
            return DataContext.Instance.Categories.Include(c => c.Annonces).ThenInclude(a => a.Annonce).ThenInclude(a => a.Images).FirstOrDefault(c => c.Id == id).Annonces.Select(a => a.Annonce).ToList();
        }
    }
}
