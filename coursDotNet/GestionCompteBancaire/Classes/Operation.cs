using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class Operation
    {
        //private int numero;
        private int id;
        private int compteId;
        private decimal montant;
        private static int index = 0;
        //public int Numero { get => numero; }
        public decimal Montant { get => montant; }
        public int Id { get => id; set => id = value; }
        public int CompteId { get => compteId; set => compteId = value; }

        private Operation()
        {
            //index++;
            //numero = index;
            //numero = ++index;
        }

        public Operation(decimal m, int compteId) : this()
        {
            CompteId = compteId;
            montant = m;
        }

        public override string ToString()
        {
            return "Id opération : " + Id + "\n" +
                "Montant opération : "+ Montant;
        }
    }
}
