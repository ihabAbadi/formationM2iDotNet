using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Voiture
    {
        //atributs
        public string model;
        public string immatriculation;
        public int nombreKm;

        //Constructeurs
        public Voiture()
        {
            
        }
        public Voiture(string m, string i)
        {
            model = m;
            immatriculation = i;
        }
        public Voiture(string m, string i, int n) : this(m,i)
        {
            //model = m;
            //immatriculation = i;
            nombreKm = n;
        }
        //Méthodes
        public void Afficher()
        {
            Console.WriteLine("Immatriculation : " + immatriculation);
            Console.WriteLine("Model : " + model);
            Console.WriteLine("nombre KM : " + nombreKm);
        }

        public string Information()
        {
            return "Immatriculation : " 
                + immatriculation + 
                " Model : " 
                + model + 
                " nombre KM " 
                + nombreKm;
        }

        public void Rouler(int nombreKm)
        {
            this.nombreKm += nombreKm;
            Afficher();
        }


    }
}
