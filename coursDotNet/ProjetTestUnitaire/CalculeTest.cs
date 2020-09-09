using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using coursDotNet.Classes;

namespace ProjetTestUnitaire
{
    [TestClass]
    public class CalculeTest
    {
        [TestMethod]
        public void Addition_Test()
        {
            //Arrange
            Calcule calcule = new Calcule();
            //Act
            double result = calcule.Addition(10, 20, 30);
            //Assert
            //Assert Equal
            Assert.AreEqual(60, result);
        }
    }
}
