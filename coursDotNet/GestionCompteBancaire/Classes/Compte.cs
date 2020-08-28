using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class Compte
    {
        private string numero;
        private int id;
        private Client client;

        protected decimal solde;

        private List<Operation> operations;

        
        public string Numero { get => numero; }
        public decimal Solde { get => solde; }
        public Client Client { get => client; }
        public List<Operation> Operations { get => operations; }
        public int Id { get => id; set => id = value; }

        public Compte(Client c, decimal s = 0 )
        {
            //Génaration d'une chaine de caractère unique
            numero = Guid.NewGuid().ToString();
            client = c;
            solde = s;
            operations = new List<Operation>();
        }

        public virtual bool Depot(Operation o)
        {
            if(o.Montant <= 0)
            {
                return false;
            }
            operations.Add(o);
            solde += o.Montant;
            return true;
        }

        public virtual bool Retrait(Operation o)
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
