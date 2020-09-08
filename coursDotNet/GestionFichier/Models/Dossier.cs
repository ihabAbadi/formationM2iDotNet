using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GestionFichier.Models
{
    class Dossier
    {
        private string nom;
        private string chemin;
        private List<Fichier> fichiers;
        private List<ExtensionFichier> extensions;

        public string Nom { get => nom; set => nom = value; }
        public string Chemin { get => chemin; set => chemin = value; }
        public List<Fichier> Fichiers { get => fichiers; set => fichiers = value; }
        public List<ExtensionFichier> Extensions { get => extensions; set => extensions = value; }

        public Dossier()
        {
            Fichiers = new List<Fichier>();
            Extensions = new List<ExtensionFichier>();
        }
        public static List<Fichier> GetFiles(string chemin)
        {
            List<Fichier> tmpFichiers = new List<Fichier>();
            List<string> stringSubFolders = Directory.EnumerateDirectories(chemin).ToList();
            if(stringSubFolders.Count > 0)
            {
                stringSubFolders.ForEach((d) =>
                {
                    tmpFichiers.AddRange(GetFiles(d));
                });
            }
            else
            {
                List<string> stringFiles = Directory.EnumerateFiles(chemin).ToList();
                stringFiles.ForEach((e) =>
                {
                    tmpFichiers.Add(new Fichier(e));
                });
            }
            return tmpFichiers;
        }

        public void GetExtensions()
        {
            foreach(Fichier f in Fichiers)
            {
                if(Extensions.FirstOrDefault(e => e.Nom == f.Extension.Nom) == null)
                {
                    Extensions.Add(f.Extension);
                }
            }
        }
    }
}
