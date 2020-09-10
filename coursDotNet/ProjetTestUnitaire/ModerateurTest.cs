using Forum.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTestUnitaire
{
    [TestClass]
    public class ModerateurTest
    {
        [TestMethod]
        public void Test_AjouterAbonne_NOT_NULL()
        {
            //arrange
            Moderateur m = new Moderateur("toto", "tata", 33);
            Mock<IForum> mockForum = new Mock<IForum>();
            mockForum.Setup((f) => f.Abonnes).Returns(new List<Abonne>());
            //Act
            Abonne a = m.AjouterAbonne(mockForum.Object, "titi", "minet", 30);
            //Assert
            Assert.IsInstanceOfType(a, typeof(Abonne));
        }

        [TestMethod] 
        public void Test_BannirAbonne()
        {
            //Arrange
            Moderateur m = new Moderateur("toto", "tata", 33);
            Abonne a = new Abonne("toto", "tata", 30);
            //Act
            m.BannirAbonne(a);
            //assert
            Assert.AreEqual(a.Statut, "banni");
            
        }
    }
}
