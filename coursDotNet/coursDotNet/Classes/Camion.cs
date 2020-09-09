using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    public class Camion : Vehicule, IAffichable
    {
        public Camion(int a, decimal p) : base(a, p)
        {

        }

        public override void Accelerer()
        {
            Console.WriteLine("Le camion immatriculé "+ Immatriculation+" accélère");
        }

        public void Afficher()
        {
            Console.WriteLine("Coucou je suis un camion");
            Console.WriteLine(this);
        }

        public override void Demarrer()
        {
            Console.WriteLine("Le camion immatriculé "+ Immatriculation+" démarre");
        }
    }
}
