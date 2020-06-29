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
    public class PlaylistTest

    {

        [TestMethod]
        public void GetAllPlaylist()
        {
            var options = new DbContextOptionsBuilder<FlixContext>()
         .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
         .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new FlixContext(options))
            {
                context.Playlists.Add(new Playlist { Id = 1, Title = "Mafia",UserId = 1 });
                context.Playlists.Add(new Playlist { Id = 2, Title = "Comedy", UserId = 1});
                context.Playlists.Add(new Playlist { Id = 3, Title = "Action", UserId = 1});
                context.Playlists.Add(new Playlist { Id = 4, Title = "Action", UserId = 2 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                PlaylistRepository playlistRepo = new PlaylistRepository(context);
                var playlists = playlistRepo.GetAllPlaylists();

                Assert.AreEqual(4, playlists.Count);

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
                PlaylistRepository userRepo = new PlaylistRepository(context);
                var playlist = userRepo.GetPlaylistById(1);

                Assert.AreEqual("Mafia", playlist.Title);
                Assert.AreEqual(1, playlist.UserId);
                context.Dispose();
            }

        }

        [TestMethod]
        public void AddPlayloist()
        {

            string title = "Super Hero";
            int userId = 2;


            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                PlaylistRepository playlist = new PlaylistRepository(context);
                var users = playlist.AddPlaylist(title, userId );

                Assert.AreEqual(title,users.Title);
                Assert.AreEqual(userId, users.Id);

                context.Dispose();

            }

        }

        [TestMethod]
        public void DeleteByPlaylistId()
        {
            var options = new DbContextOptionsBuilder<FlixContext>()
         .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
         .Options;

            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                PlaylistRepository playlistRepo = new PlaylistRepository(context);
                var playlist = playlistRepo.DeletePlayListById(1);
                var getAllPlaylist = playlistRepo.GetAllPlaylists();

                Assert.AreEqual(4, getAllPlaylist.Count);

                context.Dispose();
            }
        }

        [TestMethod]
        public void    GetListofPlaylistbyUserId()
        {

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;


            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                PlaylistRepository userRepo = new PlaylistRepository(context);
                var playlist = userRepo.GetAllPlaylistByUserId(1);

                Assert.AreEqual(3, playlist.Count);

                context.Dispose();
            }

        }

        [TestMethod]
        public void EditTitlePlaylist()
        {

            string titleofPlaylist = "Mafia Collection";
            int id = 1;

            var options = new DbContextOptionsBuilder<FlixContext>()
            .UseInMemoryDatabase(databaseName: "FlixUsersDatabase")
            .Options;


            // Use a clean instance of the context to run the test
            using (var context = new FlixContext(options))
            {
                PlaylistRepository userRepo = new PlaylistRepository(context);
                var playlist = userRepo.EditPlayList(titleofPlaylist, id);
                var findId = userRepo.GetPlaylistById(1);

                Assert.AreEqual(titleofPlaylist, findId.Title);

                context.Dispose();
            }

        }


    }

}


