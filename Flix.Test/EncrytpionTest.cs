using Flix.API.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flix.Api.UnitTest
{
    [TestClass]
    public class EncrytpionTest
    {
        [TestMethod]
        public void Encyrption()
        {

            // Arrange

            string password = "Test";
            var encyrption = new EncrytpionRepository(password);

            // Act
            var result = encyrption.ReturnEncrpyt();

            // Assert
         
            Assert.AreEqual("MGzYMsUyPHfnIfSDNsdRrQ==",result);
        }

        [TestMethod]
        public void Dencrpyt()
        {

            // Arrange

            string dytePassword = "MGzYMsUyPHfnIfSDNsdRrQ==";
            var encyrption = new EncrytpionRepository(dytePassword);

            // Act
            var result = encyrption.ReturnDencrpyt();

            // Assert

            Assert.AreEqual("Test",result);
        }

    }
}
