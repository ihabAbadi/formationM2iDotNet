using GestionCompteBancaire.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1 };
            bool result = compte.Depot(o);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DepotTest_False()
        {
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(-100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1 };
            bool result = compte.Depot(o);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DepotTest_Solde()
        {
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1 };
            compte.Depot(o);
            Assert.AreEqual(100,compte.Solde);
        }

        [TestMethod]
        public void RetraitTest_True()
        {
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(-100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1, Solde=150 };
            bool result = compte.Retrait(o);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RetraitTest_False()
        {
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1, Solde = 150 };
            bool result = compte.Retrait(o);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RetraitTest_Solde()
        {
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(-100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1, Solde = 150 };
            compte.Retrait(o);
            Assert.AreEqual(50, compte.Solde);
        }
        [TestMethod]
        public void RetraitTest_Solde_Negatif()
        {
            Mock<ISauvegarde> sauvegarde = new Mock<ISauvegarde>();
            Operation o = new Operation(-100, 1);
            sauvegarde.Setup((s) => s.addOperation(o)).Returns(true);
            Compte compte = new Compte(sauvegarde.Object) { Id = 1 };
            bool result = compte.Retrait(o);
            Assert.IsFalse(result);
        }

    }
}
