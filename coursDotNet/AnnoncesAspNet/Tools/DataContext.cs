using AnnoncesAspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnoncesAspNet.Tools
{
    public class DataContext : DbContext
    {
        public DbSet<Annonce> Annonces { get; set; }

        public DbSet<Categorie> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrateur\Desktop\Formation\entity.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
