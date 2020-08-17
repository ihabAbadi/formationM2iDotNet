using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class ClsSalarie
    {
        private string matricule;
        private string categorie;
        private string service;
        private string nom;
        private decimal salaire;

        public string Matricule { get => matricule; set => matricule = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Service { get => service; set => service = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Salaire { get => salaire; set => salaire = value; }

        private static int nombreSalarie = 0;

        public static int NombreSalarie
        {
            get
            {
                return nombreSalarie;
            }
        }
        public ClsSalarie()
        {
            nombreSalarie++;
            Console.WriteLine("Construction d'un salarié");
        }

        public ClsSalarie(string matricule, string categorie, string service, string nom, decimal salaire) : this()
        {
            Matricule = matricule;
            Categorie = categorie;
            Service = service;
            Nom = nom;
            Salaire = salaire;
        }

        ~ClsSalarie()
        {
            Console.WriteLine("Destruction d'un salarié");
        }
        public void CalculerSalaire()
        {
            Console.WriteLine("Le salaire de : " + Nom + " est : " + Salaire);
        }
    }
}
