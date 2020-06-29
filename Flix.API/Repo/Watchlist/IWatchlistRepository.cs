using System;
using System.Collections;
using System.Collections.Generic;
using Flix.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flix.API.Repo.Users
{
    public interface IWatchlistRepository
    {
        List<Watchlist> GetMoviesByPlaylistId(int playListId);
        Watchlist AddMovie(string title, int playListId, string posterPath);
        Watchlist DeleteMovieFromPlaylist(int Id);
        Watchlist GetWatchlistById(int Id);
        List<Watchlist> Getall();
    }
}
