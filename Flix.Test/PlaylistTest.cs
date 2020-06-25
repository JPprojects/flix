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
                context.Playlists.Add(new Playlist { Id = 3, Title = "Action", UserId = 2 });
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

    }

}



