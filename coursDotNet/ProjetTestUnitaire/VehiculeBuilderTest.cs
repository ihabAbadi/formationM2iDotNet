using coursDotNet.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTestUnitaire
{
    [TestClass]
    public class VehiculeBuilderTest
    {
        [TestMethod]
        public void BuildVehicule_Test_Camion()
        {
            VehiculeBuilder builder = new VehiculeBuilder();
            Vehicule result = builder.BuildVehicule("camion");
            Assert.IsInstanceOfType(result, typeof(Camion));
        }

        [TestMethod]
        public void BuildVehicule_Test_Not_Voiture_And_Not_Camion()
        {
            VehiculeBuilder builder = new VehiculeBuilder();
            Vehicule result = builder.BuildVehicule("coucou");
            Assert.IsNull(result);
        }

 

        [TestMethod]
        public void BuildVehicule_Test_Voiture()
        {
            VehiculeBuilder builder = new VehiculeBuilder();
            Vehicule result = builder.BuildVehicule("voiture");
            Assert.IsInstanceOfType(result, typeof(Voiture));
        }
    }
}
