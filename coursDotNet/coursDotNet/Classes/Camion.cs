using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Camion : Vehicule
    {
        public Camion(int a, decimal p) : base(a, p)
        {

        }

        public override void Accelerer()
        {
            Console.WriteLine("Le camion immatriculé "+ Immatriculation+" accélère");
        }

        public override void Demarrer()
        {
            Console.WriteLine("Le camion immatriculé "+ Immatriculation+" démarre");
        }
    }
}
