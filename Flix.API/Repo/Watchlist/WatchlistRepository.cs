using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Models;
using Flix.API.Repo.Users;

namespace Flix.API.Repo.Users
{


    public class WatchlistRepository : IWatchlistRepository
    {
        private  FlixContext context;

        public WatchlistRepository(FlixContext context)
        {
            this.context = context;
        }

        public Watchlist AddMovie(string title, int playListId)
        {
            var watchlist = new Watchlist()
            {
                MovieTitle = title,
                PlaylistId = playListId
            };

            context.Watchlists.Add(watchlist);
            context.SaveChanges();
            return watchlist;
        }

        public Watchlist DeleteMovieFromPlaylist(int Id)
        {
            var watchlist = GetWatchlistById(Id);
            context.Watchlists.Remove(watchlist);
            context.SaveChanges();
            return watchlist;
        }

        public List<Watchlist> GetMoviesByPlaylistId(int playListId)
        {

            return context.Watchlists.Where(i => i.PlaylistId == playListId).ToList();
        }

        public Watchlist GetWatchlistById(int Id)
        {
            return context.Watchlists.Find(Id);
        }
    }
}
