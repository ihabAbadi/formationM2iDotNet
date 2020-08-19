using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class ComptePayant : Compte
    {
        private int coutOperation;

        public int CoutOperation { get => coutOperation; set => coutOperation = value; }
    }
}
