using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    abstract class Vehicule
    {
        private int immatriculation;
        private int anneeModel;
        private decimal prix;

        private static int tmpImmatriculation = 0;

        public int Immatriculation { get => immatriculation; set => immatriculation = value; }
        public int AnneeModel { get => anneeModel; set => anneeModel = value; }
        public decimal Prix { get => prix; set => prix = value; }

        public Vehicule()
        {
            tmpImmatriculation++;
            Immatriculation = tmpImmatriculation;
        }
        public Vehicule(int a, decimal p) : this()
        {
            AnneeModel = a;
            Prix = p;
        }

        abstract public void Demarrer();

        abstract public void Accelerer();

        public override string ToString()
        {
            return "Immatriculation : " + Immatriculation + " Année : " + AnneeModel + " Prix : " + Prix;
        }
    }
}
