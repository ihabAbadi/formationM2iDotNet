using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    public class VehiculeBuilder
    {
        public Vehicule BuildVehicule(string type)
        {
            if(type == "camion")
            {
                return new Camion(2010, 15000);
            }
            else if(type == "voiture")
            {
                return new Voiture(2020, 20000);
            }
            else
            {
                return null;
            }
        }
    }
}
