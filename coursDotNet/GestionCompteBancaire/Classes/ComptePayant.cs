﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class ComptePayant : Compte
    {
        private int coutOperation;

        public int CoutOperation { get => coutOperation; set => coutOperation = value; }

        public ComptePayant(Client c, int cOperation = 2, decimal s = 0) : base(c,s)
        {
            coutOperation = cOperation;
        }

        public override bool Depot(Operation o)
        {
            if(o.Montant >= CoutOperation)
            {
                if(base.Depot(o))
                {
                    Operation oRetrait = new Operation(CoutOperation * -1);
                    return base.Retrait(oRetrait);
                }
                return false;
            }
            return false;
        }

        public override bool Retrait(Operation o)
        {
            if(Math.Abs(o.Montant)+ CoutOperation <= Solde)
            {
                //Operation oRetrait = new Operation(CoutOperation * -1);
                //return base.Retrait(o) && base.Retrait(oRetrait);
                return base.Retrait(o) && base.Retrait(new Operation(CoutOperation * -1));
            }
            return false;
        }
    }
}