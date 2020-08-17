using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Voiture
    {
        //atributs
        private string model;
        private string immatriculation;
        private int nombreKm;
        //propriétés

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public string Immatriculation { get => immatriculation; set => immatriculation = value; }
        public int NombreKm { get => nombreKm; set => nombreKm = value; }

        //Constructeurs
        public Voiture()
        {
            nombreVoitures++;
        }
        public Voiture(string m, string i) : this()
        {
            model = m;
            Immatriculation = i;
        }
        public Voiture(string m, string i, int n) : this(m,i)
        {
            //model = m;
            //immatriculation = i;
            NombreKm = n;
        }
        //Méthodes
        public void Afficher()
        {
            Console.WriteLine("Immatriculation : " + Immatriculation);
            Console.WriteLine("Model : " + Model);
            Console.WriteLine("nombre KM : " + NombreKm);
        }

        public string Information()
        {
            return "Immatriculation : " 
                + Immatriculation + 
                " Model : " 
                + Model + 
                " nombre KM " 
                + NombreKm;
        }

        public void Rouler(int nombreKm)
        {
            this.NombreKm += nombreKm;
            Afficher();
        }

        //Destructeur
        ~Voiture()
        {
            Console.WriteLine("Desctruction de l'objet");
        }
        //Eléments statiques
        public static int nombreVoitures = 0; 

    }
}
