using AcebookApi.Models;
using Flix.API.Repo;
using Flix.API.Repo.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Flix.Api.UnitTest
{
    [TestClass]
    public class UserTest
    {

        private readonly Mock<IUserReposistory> userRepo = new Mock<IUserReposistory>();
        


       [TestMethod]
        public void AddUser()
        {
           

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
