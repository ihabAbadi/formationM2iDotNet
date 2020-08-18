using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Commerciale : ClsSalarie
    {
        private decimal chiffreAffaire;
        private int commission;

        public decimal ChiffreAffaire { get => chiffreAffaire; set => chiffreAffaire = value; }
        public int Commission { get => commission; set => commission = value; }

        public Commerciale()
        {

        }
        public Commerciale(string matricule, string categorie, string service, string nom, decimal salaire, decimal chiffreAffaire, int commission) : base(matricule, categorie, service, nom, salaire)
        {
            ChiffreAffaire = chiffreAffaire;
            Commission = commission;
        }

        public override void CalculerSalaire()
        {
            decimal newSalaire = Salaire + (chiffreAffaire * commission / 100);
            Console.WriteLine("Le salaire de : " + Nom + " est : " + newSalaire);
        }
    }
}
