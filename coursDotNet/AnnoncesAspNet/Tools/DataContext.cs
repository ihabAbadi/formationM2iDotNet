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
        private static DataContext _instance;

        private static object _lock = new object();

        public static DataContext Instance
        {
            get
            {
                lock(_lock)
                {
                    if (_instance == null)
                        _instance = new DataContext();
                    return _instance;
                }
            }
        }
        public DbSet<Annonce> Annonces { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Administrateur\Desktop\Formation\entity.mdf;Integrated Security=True;Connect Timeout=30");
        }

        private DataContext() : base()
        {

        }
    }
}
