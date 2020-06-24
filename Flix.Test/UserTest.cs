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


      

       [TestMethod]
        public void AddUser()
        {

            var user = new User()
            {
                Id = 1,
                UserName= "GlenDev",
                EmailAddress = "Test@dev.com",
                Password = "Test",
                FirstName = "Glen",
                LastName = "Get"
            };
            Mock<IUserReposistory> userRepo = new Mock<IUserReposistory>();

            // Setup Mock
            var result = userRepo.Setup(x => x.GetUserByID(1)).Returns(user);


            Assert.Equals(result, user.id);

        }
    }

        
    }
}
