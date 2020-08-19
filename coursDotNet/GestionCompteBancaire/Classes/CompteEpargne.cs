using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class CompteEpargne : Compte
    {
        private int taux;

        public int Taux { get => taux; }

        public CompteEpargne(Client c, int t, decimal s = 0) : base(c, s)
        {
            taux = t;
        }

        public void UpdateSolde()
        {
            solde += solde * taux / 100;
        }
    }
}
