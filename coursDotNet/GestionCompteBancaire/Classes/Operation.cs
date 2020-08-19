using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class Operation
    {
        private int numero;
        private decimal montant;
        private static int index = 0;
        public int Numero { get => numero; }
        public decimal Montant { get => montant; }

        private Operation()
        {
            //index++;
            //numero = index;
            numero = ++index;
        }

        public Operation(decimal m) : this()
        {
            montant = m;
        }

        public override string ToString()
        {
            return "Numéro opération : " + Numero + "\n" +
                "Montant opération : "+ Montant;
        }
    }
}
