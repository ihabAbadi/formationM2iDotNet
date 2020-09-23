using AnnoncesAspNet.Models;
using AnnoncesAspNet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.ViewModels
{
    public class AnnoncesViewModel
    {
        public List<Annonce> Annonces { get; set; }
        public List<Categorie> Categories { get; set; }

        public AnnoncesViewModel()
        {
            Annonces = new List<Annonce>();
            Categories = DataContext.Instance.Categories.ToList();
        }
    }
}
