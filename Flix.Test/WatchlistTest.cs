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
    public class WatchlistTest

    {

        [TestMethod]
        public void GetAll()
        {
            var options = new DbContextOptionsBuilder<FlixContext>()
         .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
         .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new FlixContext(options))
            {
                context.Watchlists.Add(new Watchlist { Id = 1, MovieTitle = "Goodfellas",PlaylistId = 1 });
                context.Watchlists.Add(new Watchlist { Id = 2, MovieTitle = "God father", PlaylistId = 1 }); 
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                var watchlist = new WatchlistRepository(context);
                var addMovie = watchlist.Getall();



                Assert.AreEqual(2, addMovie.Count);

                context.Dispose();

            }
        }


        [TestMethod]
        public void GetPlaylistByID()
        {

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;



            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                WatchlistRepository userRepo = new WatchlistRepository(context);
                var playlist = userRepo.GetMoviesByPlaylistId(1);

                Assert.AreEqual(2, playlist.Count);
                context.Dispose();
            }

        }

        [TestMethod]
        public void AddPlaylist()
        {

            string title = "MovieName";
            int playListId = 2;


            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                WatchlistRepository playlist = new WatchlistRepository(context);
                var users = playlist.AddMovie(title, playListId, "hello");
                var playlist1 = playlist.Getall();

                Assert.AreEqual(3, playlist1.Count);

                context.Dispose();

            }

        }


        [TestMethod]
        public void    DeleteMovieFromPlaylist()
        {

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;


            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                WatchlistRepository userRepo = new WatchlistRepository(context);
                var playlist = userRepo.DeleteMovieFromPlaylist(1);
                var getall = userRepo.Getall();

                Assert.AreEqual(2, getall.Count);

                context.Dispose();
            }

        }

        public void GetMovie()
        {

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;



            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                WatchlistRepository userRepo = new WatchlistRepository(context);
                var playlist = userRepo.GetWatchlistById(2);

                Assert.AreEqual("God father", playlist.MovieTitle);
                context.Dispose();
            }

        }




    }

}



