using GestionCompteBancaire.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTestUnitaire
{
    [TestClass]
    public class CompteTest
    {
        [TestMethod]
        public void DepotTest_True()
        {
            Compte compte = new Compte() { Id = 1 };
            Operation o = new Operation(100, 1);
            bool result = compte.Depot(o);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DepotTest_False()
        {
            Compte compte = new Compte() { Id = 1 };
            Operation o = new Operation(-100, 1);
            bool result = compte.Depot(o);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DepotTest_Solde()
        {
            Compte compte = new Compte() { Id = 1 };
            Operation o = new Operation(100, 1);
            compte.Depot(o);
            Assert.AreEqual(100,compte.Solde);
        }
    }
}
