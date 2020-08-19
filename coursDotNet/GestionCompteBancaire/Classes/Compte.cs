using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class Compte
    {
        private int numero;

        private Client client;

        private decimal solde;

        private List<Operation> operations;

        private static int index = 0;

        public int Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; }
        public List<Operation> Operations { get => operations; }

        public Compte(Client c, decimal s = 0 )
        {
            numero = ++index;
            client = c;
            solde = s;
            operations = new List<Operation>();
        }

        public bool Depot(Operation o)
        {
            if(o.Montant <= 0)
            {
                return false;
            }
            operations.Add(o);
            solde += o.Montant;
            return true;
        }

        public bool Retrait(Operation o)
        {
            if(Math.Abs(o.Montant) <= solde)
            {
                operations.Add(o);
                solde += o.Montant;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string retour = "Numero compte : "+ Numero +"\n" +
                "Client : "+ Client.ToString() +"\n" +
                "Liste operations : \n";
            foreach(Operation o in Operations)
            {
                retour += o.ToString() + "\n";
            }
            retour += "Solde : " + Solde;
            return retour;
        }
    }
}
