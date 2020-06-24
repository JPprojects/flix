using System.Collections.Generic;
using Flix.API.Models;
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
        public void GetAllUsers()
        {
            var options = new DbContextOptionsBuilder<FlixContext>()
         .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
         .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new FlixContext(options))
            {
                context.Users.Add(new User { Id = 1, UserName = "Glen", EmailAddress = "dev@test.com", Password = "MGzYMsUyPHfnIfSDNsdRrQ==", FirstName = "Glen", LastName = "dev" });
                context.Users.Add(new User { Id = 2, UserName = "Ade", EmailAddress = "dev1@test.com", Password = "MGzYMsUyPHfnIfSDNsdRrQ==", FirstName = "Dev", LastName = "dev" });
                context.Users.Add(new User { Id = 3, UserName = "Jerome", EmailAddress = "dev2@test.com", Password = "MGzYMsUyPHfnIfSDNsdRrQ==", FirstName = "Last", LastName = "dev" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                UserRepository userRepo = new UserRepository(context);
                var users = userRepo.GetAllUsers();

                Assert.AreEqual(3, users.Count);

                context.Dispose();

            }
        }

        [TestMethod]
        public void GetUserByID()
        {

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;

     

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                UserRepository userRepo = new UserRepository(context);
                var users = userRepo.GetUserByID(1);

                Assert.AreEqual("Glen", users.UserName);
                Assert.AreEqual("dev@test.com", users.EmailAddress);
                Assert.AreEqual("MGzYMsUyPHfnIfSDNsdRrQ==", users.Password);
                context.Dispose();
            }

        }

        [TestMethod]
        public void AddUser()
        {

            var newUser = new User() { Id = 4, UserName = "Glen12", EmailAddress = "dev@test.com", Password = "MGzYMsUyPHfnIfSDNsdRrQ==", FirstName = "Glen", LastName = "dev" };

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                UserRepository userRepo = new UserRepository(context);
                var users = userRepo.AddUser(newUser);

                Assert.AreEqual(users, newUser);

                context.Dispose();


            }

        }

        [TestMethod]
        public void DeleteUserByID()
        {
            var options = new DbContextOptionsBuilder<FlixContext>()
         .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
         .Options;

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                UserRepository userRepo = new UserRepository(context);
                var users = userRepo.DeleteUser(1);
                var getAllUser = userRepo.GetAllUsers();

                Assert.AreEqual(3, getAllUser.Count);

                context.Dispose();
            }
        }
    }

}

