using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class CompteEpargne : Compte
    {
        private int taux;

        public int Taux { get => taux; set => taux = value; }
    }
}
