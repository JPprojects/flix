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

        private readonly Mock<IUserReposistory> _userRepo = new Mock<IUserReposistory>();
        


       [TestMethod]
        public void AddUser()
        {
            var user = new User()
            {
                Id = 1,
                UserName = "Glen",
                EmailAddress = "Glen@dev.com",
                Password = "Test",
                FirstName = "Glen",
                LastName = "Hani"
            };

           var result = _userRepo.Setup(x => x.AddUser(user)).Returns(user);


            Assert.AreEqual(user, result);

        }

        
    }
}
