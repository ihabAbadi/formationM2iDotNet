using GestionUtilisateur;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetTestUnitaire
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestGetUserByName()
        {
            //Arrange
            Mock<IData> mock = new Mock<IData>();
            mock.Setup(p => p.GetUserByLastName("titi")).Returns(new User() { FirstName = "Titi", LastName = "MINET" });
            UserController controller = new UserController(mock.Object);
            //Act
            User user = controller.GetUserByName("titi");
            Assert.IsNotNull(user);
        }
    }
}
